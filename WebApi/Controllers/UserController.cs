using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface;
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
        private IUserService _userService;
       
        private readonly ILogger<UserController> _logger;

        public UserController(IBaseService<User> baseUserService
            , ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _baseUserService = baseUserService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {

            
            var user = _userService.GetUserForLogin(model.Email, model.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Senha = "";

            return new
            {
                user = user,
                token = token
            };
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticateGeneric")]
        public async Task<ActionResult<dynamic>> AuthenticateGeneric()
        {

          
            var user = new User()
            {
                Id = 0,
                Name = "Autenticado Generico",
                Senha = "123456789"
            };

           
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

           
            var token = TokenService.GenerateToken(user);

            
            user.Senha = "";

            
            return new
            {
                user = user,
                token = token
            };
        }
        [AllowAnonymous]
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

        [AllowAnonymous]
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
