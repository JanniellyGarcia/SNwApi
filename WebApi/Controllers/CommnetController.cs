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
    public class CommnetController : Controller
    {
        private IBaseService<Comment> _baseCommentService;
        private readonly ILogger<CommnetController> _logger;

        public CommnetController(IBaseService<Comment> baseCommentService
            , ILogger<CommnetController> logger)
        {
            _baseCommentService = baseCommentService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateComment")]
        public IActionResult Create([FromBody] Comment comment)
        {
            if (comment == null)
                return NotFound();

            return Execute(() => _baseCommentService.Add<CommentValidator>(comment).Id);
        }
        [HttpPut]
        [Route("UpdateComment")]
        public IActionResult Update([FromBody] Comment comment)
        {
            if (comment == null)
                return NotFound();

            return Execute(() => _baseCommentService.Update<CommentValidator>(comment));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCommentService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _baseCommentService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseCommentService.GetById(id));
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
