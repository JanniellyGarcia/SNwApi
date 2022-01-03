using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Service.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private IBaseService<News> _baseNewsService;
        private INewsService _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(IBaseService<News> baseNewsService
            , ILogger<NewsController> logger, INewsService newsService)
        {
            _newsService = newsService;
            _baseNewsService = baseNewsService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateNews")]
        public IActionResult Create([FromForm] News news, [FromForm] IFormFile arquivo)
        {
            if (news == null)
                return NotFound();

            if (arquivo.Length > 0)
            {
                news.Path = "C:\\images\\";
                news.TypeImage = "image/jpg";
                news.Image = arquivo.FileName;
                _newsService.uploadImagem(arquivo, news.Id);
            }

            return Execute(() => _baseNewsService.Add<NewsValidator>(news).Id);
        }
        [HttpPut]
        [Route("UpdateNews")]
        public IActionResult Update([FromBody] News news)
        {
            if (news == null)
                return NotFound();

            return Execute(() => _baseNewsService.Update<NewsValidator>(news));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseNewsService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _baseNewsService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseNewsService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error" + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
