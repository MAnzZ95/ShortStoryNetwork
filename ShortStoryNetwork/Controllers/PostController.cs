using Microsoft.AspNetCore.Mvc;
using ShortStoryNetwork.IServices;
using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.Controllers
{
    [Route("api/postInfo")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            try
            {
                var postInfo = await _postService.getAllPosts();
                return Ok(postInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Post>> InsertPost([FromBody] Post oPost)
        {

            try
            {
                if (oPost == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                else
                {
                    var post = await _postService.addEditPost(oPost);
                    return post;

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            try
            {
                if (id == 0 || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                else
                {
                    var user = await _postService.DeletePost(id);
                    return user;

                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "PostbyId")]
        public async Task<ActionResult> GetUserbyId(int id)
        {
            try
            {
                var post = await _postService.getPostbyId(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
        

       
 }

