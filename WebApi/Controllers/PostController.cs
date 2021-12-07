using Data.Migrations;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Service.Service;
using Service.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IBaseService<Post> _basePostService;
        private PostService _postService;
        private readonly ILogger<PostController> _logger;

        public PostController(IBaseService<Post> basePostService
            , ILogger<PostController> logger,  PostService postService)
        {
            _postService = postService;
            _basePostService = basePostService;
            _logger = logger;
        }
        //Criar Post
        [HttpPost]
        [Route("CreatePost")]
        public IActionResult Create([FromBody] Post post, [FromForm] IFormFile arquivo, int id)
        {
            if (post == null)
                return NotFound();
            if (arquivo.Length > 0)
            {
                post.Path = "C:\\images\\";
                post.Type = "image/jpg";
                post.Image = arquivo.FileName;
                _postService.uploadImagem(arquivo, id);
            }
            return Execute(() => _basePostService.Add<PostValidator>(post).Id);
        }




        //atualizar post
        [HttpPut]
        public IActionResult Update([FromBody] Post post)
        {
            if (post == null)
                return NotFound();

            return Execute(() => _basePostService.Update<PostValidator>(post));
        }

        [HttpDelete("Delete/{id}")]
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
                return BadRequest(ex.Message);
            }
        }
    }
}


