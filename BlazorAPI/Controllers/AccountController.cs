using BlazorAPI.Models;
using BlazorAPI.Repositories;
using BlazorAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public AccountController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Route("Registration")]
        [HttpPost]
        public async Task Registration([FromBody] RegisterViewModel registerViewModel)
        {
            await userRepository.AddUserAsync(registerViewModel);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<User> Login(LoginViewModel loginViewModel)
        {
            User user = await userRepository.GetUserAsync(loginViewModel);
            return user;
        }
    }
}
