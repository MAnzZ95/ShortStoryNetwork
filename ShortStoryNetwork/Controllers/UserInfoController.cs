using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortStoryNetwork.IServices;
using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.Controllers
{
    [Route("api/userInfo")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfo _userInfoService;

        public UserInfoController(IUserInfo userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var user = await _userInfoService.getAllUsers();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "UserbyId")]
        public async Task<ActionResult> GetUserbyId(int id)
        {
            try
            {
                var user = await _userInfoService.getUserbyId(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<UserInfo>> RegistertUser([FromBody] UserInfo userInfo)
        {
          var existingUser = await _userInfoService.isEmailExists(userInfo.EmailAddress); 
            try
            {
                if (userInfo == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }                
                else if(existingUser != null)
                {
                    return BadRequest("Email Already Exists");
                }
                else
                {
                    var user = await _userInfoService.addEditUser(userInfo);
                    return user;
                   
                }               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserInfo>> UpdateEmployee(UserInfo userInfo)
        {
            try
            {
                if (userInfo == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                else
                {
                    var user = await _userInfoService.addEditUser(userInfo);
                    return user;
                   
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInfo>> DeleteById(int id)
        {
            try
            {
                if (id == 0 || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                else
                {
                    var user = await _userInfoService.DeleteUser(id);
                    return user;
                    
                }
                           
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
