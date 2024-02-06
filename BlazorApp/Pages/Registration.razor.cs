using BlazorApp.Models;
using BlazorApp.Repositories;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Registration : ComponentBase
    {
        [Inject]
        protected UserRepository userRepository { get; set; }

        protected RegistrationModel registrationModel { get; set; } = new RegistrationModel();

        protected async Task RegisterAsync()
        {
            await userRepository.AddUserAsync(registrationModel);
        }
    }
}
