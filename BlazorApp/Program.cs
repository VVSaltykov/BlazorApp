using BlazorApp.Data;
using BlazorApp.Repositories;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<CookieService>();

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddTransient<UserRepository>()
                            .AddTransient<CompetitonRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
