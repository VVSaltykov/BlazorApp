using BlazorApp.Models;
using BlazorApp.Repositories;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected UserRepository UserRepository { get; set; }

        [Inject]
        protected CookieService CookieService { get; set; }

        protected LoginModel loginModel { get; set; } = new LoginModel();
        protected bool IsLoginFailed { get; set; } = false;

        protected async Task LoginAsync()
        {
            var user = await UserRepository.GetUserAsync(loginModel);
            if (user != null)
            {
                await CookieService.SetUserCookie(user);

                NavigationManager.NavigateTo("/home");
            }
            else
            {
                IsLoginFailed = true;
            }
        }
    }
}
