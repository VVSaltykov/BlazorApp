using BlazorApp.Models;
using Microsoft.JSInterop;

namespace BlazorApp.Services
{
    public class CookieService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IJSRuntime jSRuntime;

        public CookieService(IHttpContextAccessor httpContextAccessor, IJSRuntime jSRuntime)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.jSRuntime = jSRuntime;
        }

        public async Task SetUserCookie(User user)
        {
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                IsEssential = true
            };
            httpContextAccessor.HttpContext.Response.Cookies.Append("UserId", user.Id.ToString(), options);

            await jSRuntime.InvokeVoidAsync("setCookie", "UserId", user.Id.ToString());
        }
    }
}
