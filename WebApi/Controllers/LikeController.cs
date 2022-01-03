using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class LikeController : Controller
    {
        private IBaseService<Like> _baseLikeService;
        private readonly ILogger<LikeController> _logger;

        public LikeController(IBaseService<Like> baseLikeService
            , ILogger<LikeController> logger)
        {
            _baseLikeService = baseLikeService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateLike")]
        public IActionResult Create([FromBody] Like like)
        {
            if (like == null)
                return NotFound();


            return Execute(() => _baseLikeService.Add<LikeValidator>(like).Id);
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseLikeService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _baseLikeService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseLikeService.GetById(id));
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
