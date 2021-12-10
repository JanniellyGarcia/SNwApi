using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Configuration;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseUserService;
        private readonly ILogger<UserController> _logger;

        public UserController(IBaseService<User> baseUserService
            , ILogger<UserController> logger)
        {
            _baseUserService = baseUserService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao(string login, string password)
        {
            if(login == "teste" && password == "teste")
            {
                var user = new User();
                user.Name = "Jannielly";
                var token = TokenService.GenerateToken(user);
                return new { token = token };
            }
            else
            {
                return NotFound(new { mensagem = "Usuário não encontrado!" });
            }
        }

        [HttpGet("authenticate")]
        public string Authenticate()
        {
            return String.Format("Autenticado - {0}", User.Identity.Name);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<UserValidator>(user).Id);
        }
        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UserValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            _logger.LogInformation("Teste");
            return Execute(() => _baseUserService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById(id));
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
