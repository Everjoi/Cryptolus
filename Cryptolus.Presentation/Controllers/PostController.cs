using Cryptolus.Application.Common.Interfaces;
using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Application.DTOs;
using Cryptolus.Domain.Entities.Post;
using Cryptolus.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace Cryptolus.Presentation.Controllers
{
    //CRUD 
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository, IAuthenticationService authenticationService, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("/delete/post/id")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await _postRepository.DeleteAsync(await _postRepository.GetByIdAsync(id));
            return Ok(Task.CompletedTask); 
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("/create/post")]
        public  IActionResult  CreatePost([FromBody] PostDto post)
        {
            var newPost = new Post
            {
                Id = new Guid(),
                Author = GetAuthor(),
                Content = post.Content,
                CreateDate = DateTime.Now,
                ViewsCount  = 0,

            };
            if(post.KeyThemes is not null)
            {
                newPost.PostThemes = post.KeyThemes.Select(theme => new PostThemes
                {
                    Post = newPost,
                    Theme = theme
                }).ToList();
            }
            
             
            return Ok(newPost);
        }


        [HttpPost("/update/post/{id}")]
        public async Task<IActionResult> UpdatePost([FromBody] Post post)
        {
           await _postRepository.UpdateAsync(post);
           return Ok(post);
        }




        public Author GetAuthor()
        {
            var claims =  HttpContext.User.Claims.ToList();
            var id = claims.FirstOrDefault(x => x.Type == ClaimTypes.Actor)?.Value.ToString();
            var author = _unitOfWork.Repository<User>().GetByIdAsync(Guid.Parse(id)).Result;

            var result = new Author
            {
                Id = author.Id,
                Email = author.Email,
                Photo = author.Photo,
                UserName = author.UserName
            };

            return result;
        }
        

        [HttpGet("get/allpost/")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }


        [HttpGet("get/postByDate/")]
        public async Task<IActionResult> GetPostsByDate(DateTime dateTime)
        {
            var posts = await _postRepository.GetPostsByDate(dateTime);
            return Ok(posts);
        }



        [HttpGet("get/postByDatePeriod/")]
        public async Task<IActionResult> GetPostsByPeriod(DateTime start, DateTime end)
        {
            var posts = await _postRepository.GetPostsByPeriod(start,end);
            return Ok(posts);
        }


        [HttpGet("get/postByTheme/")]
        public async Task<IActionResult> GetPostsByThemes(List<Themes> themes)
        {
            var posts = await _postRepository.GetPostsByThemes(themes);
            return Ok(posts);
        }

    }
}
