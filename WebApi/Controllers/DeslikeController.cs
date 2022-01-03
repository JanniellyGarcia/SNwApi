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
    public class DeslikeController : Controller
    {
        private IBaseService<Deslike> _baseDeslikeService;
        private readonly ILogger<DeslikeController> _logger;

        public DeslikeController(IBaseService<Deslike> baseDeslikeService
            , ILogger<DeslikeController> logger)
        {
            _baseDeslikeService = baseDeslikeService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateDeslike")]
        public IActionResult Create([FromBody] Deslike deslike)
        {
            if (deslike == null)
                return NotFound();


            return Execute(() => _baseDeslikeService.Add<DeslikeValidator>(deslike).Id);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseDeslikeService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _baseDeslikeService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseDeslikeService.GetById(id));
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
