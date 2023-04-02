using BlazorAPI.Models;
using BlazorAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task AddUserAsync(RegisterViewModel registerViewModel)
        {
            User user = new User
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
            }; 
            await applicationContext.Users.AddAsync(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(LoginViewModel loginViewModel)
        {
            User user = await applicationContext.Users.FirstOrDefaultAsync(u => u.Name == loginViewModel.Name);
            return user;
        }
    }
}
