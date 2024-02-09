using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task AddUserAsync(RegistrationModel registrationModel)
        {
            User user = new User
            {
                Login = registrationModel.Login,
                Email = registrationModel.Email,
                Password = registrationModel.Password,
                Role = registrationModel.Role,
            };
            applicationContext.Users.Add(user);
            await applicationContext.SaveChangesAsync();
        }
        public async Task<User> GetUserAsync(LoginModel loginModel)
        {
            var user = await applicationContext.Users
                .FirstOrDefaultAsync(u => u.Login == loginModel.Login && u.Password == loginModel.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<bool> CheckUserAsync(RegistrationModel registrationModel)
        {
            bool check = true;
            if (applicationContext.Users.Where(u => u.Login == registrationModel.Login).Any())
            {
                check = false;
                return check;
            }
            return check;
        }
    }
}
