using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Service.Service;
using Service.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IBaseService<Post> _basePostService;
        private IPostService _postService;
        private ILikeService _likeService;
        private IPostRepository _postRepository;
        private readonly ILogger<PostController> _logger;

        public PostController(IBaseService<Post> basePostService
            , ILogger<PostController> logger,  IPostService postService)
        {
            _postService = postService;
            _basePostService = basePostService;
            _logger = logger;
        }

        

        [HttpGet("authenticate")]
        public string Authenticate()
        {
            return String.Format("Autenticado - {0}", User.Identity.Name);
        }


        //Criar Post
        [HttpPost]
        [Route("CreatePost")]
        public IActionResult Create([FromForm] Post post, [FromForm] IFormFile arquivo )
        {
            if (post == null )
                return NotFound();

            if (arquivo.Length > 0)
            {
                post.Path = "C:\\images\\";
                post.Type = "image/jpg";
                post.Image = arquivo.FileName;
                _postService.uploadImagem(arquivo, post.Id);
            }
            

            return Execute(() => _basePostService.Add<PostValidator>(post).Id);
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(string arquivo)
        {
            var path = "C:\\images\\";
            var filepath = path + arquivo;

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, "image/png", Path.GetFileName(filepath));
        }


        //atualizar post
        [HttpPut]
        public IActionResult Update([FromBody] Post post)
        {
            if (post == null)
                return NotFound();

            return Execute(() => _basePostService.Update<PostValidator>(post));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _basePostService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }
        [HttpGet("QuantidadeDeCurtidas")]
        public IActionResult GetLikeDoPost()
        {
            return Execute(() => _postRepository.GetLikeDoPost());
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _basePostService.Get());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _basePostService.GetById(id));
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


