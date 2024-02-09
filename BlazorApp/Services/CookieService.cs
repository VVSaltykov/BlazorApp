using BlazorApp.Models;
using Microsoft.JSInterop;

namespace BlazorApp.Services
{
    public class CookieService
    {
        private readonly IJSRuntime jSRuntime;

        public CookieService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task SetUserCookie(User user)
        {
            await jSRuntime.InvokeVoidAsync("blazorExtensions.SetCookie", "Id", user.Id.ToString(), 3600);
        }
    }
}
