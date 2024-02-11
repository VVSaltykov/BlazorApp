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

        protected SchoolRepository SchoolRepository { get; set; }

        [Inject]
        protected UserRepository UserRepository { get; set; }

        protected RegistrationModel registrationModel { get; set; } = new RegistrationModel();
        private bool IsRegistered { get; set; } = false;
        private List<School> Schools = new List<School>();

        protected override async Task OnInitializedAsync()
        {
            Schools = await SchoolRepository.GetSchoolsAsync();
        }

        protected async Task RegisterAsync()
        {
            if (await UserRepository.CheckUserAsync(registrationModel))
            {
                await UserRepository.AddUserAsync(registrationModel);

                NavigationManager.NavigateTo("/login");
            }
            else
            {
                IsRegistered = true;
            }
        }
    }
}
