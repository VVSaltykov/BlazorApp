using BlazorApp.Models;
using BlazorApp.Repositories;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Registration : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected UserRepository userRepository { get; set; }

        protected RegistrationModel registrationModel { get; set; } = new RegistrationModel();
        private bool IsRegistered { get; set; } = false;

        protected async Task RegisterAsync()
        {
            if (await userRepository.CheckUserAsync(registrationModel))
            {
                await userRepository.AddUserAsync(registrationModel);

                NavigationManager.NavigateTo("/login");
            }
            else
            {
                IsRegistered = true;
            }
        }
    }
}
