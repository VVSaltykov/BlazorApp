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
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected UserRepository UserRepository { get; set; }

        protected LoginModel loginModel { get; set; } = new LoginModel();
        protected bool IsLoginFailed { get; set; } = false;

        protected async Task LoginAsync()
        {
            var user = await UserRepository.GetUserAsync(loginModel);
            if (user != null)
            {
                var cookieService = new CookieService(HttpContextAccessor, JSRuntime);
                await cookieService.SetUserCookie(user);
            }
        }
    }
}
