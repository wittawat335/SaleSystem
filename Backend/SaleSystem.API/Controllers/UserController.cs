﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Core.DTO;
using SaleSystem.Core.Services.Contract;
using SaleSystem.Infrastructure.Utility;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = new Response<List<UserDTO>>();
            try
            {
                response.value = await _userService.GetList();
                response.status = Constants.Status.True;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var response = new Response<SessionDTO>();
            try
            {
                string key = _configuration.GetSection(Constants.AppSettings.JWT_Key).Value!;
                response.value = await _userService.Login(login.Email!, login.Password!, key);
                response.status = Constants.Status.True;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            var response = new Response<UserDTO>();
            try
            {
                response.value = await _userService.Create(user);
                response.status = Constants.Status.True;
                response.message = Constants.StatusMessage.Create_Action;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            var response = new Response<bool>();
            try
            {
                response.value = await _userService.Update(user);
                response.status = Constants.Status.True;
                response.message = Constants.StatusMessage.Update_Action;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = new Response<bool>();
            try
            {
                var userId = new Guid(id);
                response.value = await _userService.Delete(userId);
                response.status = Constants.Status.True;
                response.message = Constants.StatusMessage.Delete_Action;
            }
            catch (Exception ex)
            {
                response.status = Constants.Status.False;
                response.message = ex.Message;
            }
            return Ok(response);
        }
    }
}
