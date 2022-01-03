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
    public class ChatController : Controller
    {
        private IBaseService<Chat> _baseChatService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IBaseService<Chat> baseChatService
            , ILogger<ChatController> logger)
        {
            _baseChatService = baseChatService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateChat")]
        public IActionResult Create([FromBody] Chat chat)
        {
            if (chat == null)
                return NotFound();

            return Execute(() => _baseChatService.Add<ChatValidator>(chat).Id);
        }
        [HttpPut]
        [Route("UpdateChat")]
        public IActionResult Update([FromBody] Chat chat)
        {
            if (chat == null)
                return NotFound();

            return Execute(() => _baseChatService.Update<ChatValidator>(chat));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseChatService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _baseChatService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseChatService.GetById(id));
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
