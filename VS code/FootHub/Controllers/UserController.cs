using FootHub.Execptions;
using FootHub.Models;
using FootHub.Services.UserServices;
using FootHub.UIFormatting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FootHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _userServices;

        public UserController(IUser userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usercls>>> GetUsersList()
        {
            var usersList = await _userServices.GetUsersList();
            var display = Usercls.GetUsers(usersList);
            return Ok(display);
        }

        [HttpPost]
        public async Task<ActionResult<UserTable>> SignUp(UserTable user)
        {
            UserTable newUser;
            Usercls display;
            try
            {
                newUser = await _userServices.SignUp(user);
                display = Usercls.GetUser(newUser);
            }
            catch (Exception msg)
            {
                return NotFound(msg.Message);
            }
            return Ok(display);
        }

        [HttpGet("{id},{password}")]
        public async Task<ActionResult<UserTable>> Login(string id, string password)
        {
            UserTable user;
            try
            {
                user = await _userServices.Login(id, password);
            }
            catch (Exception msg)
            {
                return NotFound(msg.Message);
            }
            return Ok(user);
        }

        [HttpDelete("{id},{password}")]
        public async Task<ActionResult<string>> DeleteAccount(string id, string password)
        {
            string user;
            try
            {
                user = await _userServices.DeleteAccount(id, password);
            }
            catch (Exception msg)
            {
                return NotFound(msg.Message);
            }
            return Ok(user);
        }

        [HttpPut("{id},{password}")]
        public async Task<ActionResult<string>> UpdateAccount(string id, string password,UserUpdate user)
        {
            string updatedUser;
            try
            {
                updatedUser=await _userServices.UpdateAccount(id,password,user);
            }
            catch (Exception msg)
            {
                return NotFound(msg.Message);
            }
            return Ok(updatedUser);
        }



    }
}
