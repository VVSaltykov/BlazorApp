using BlazorApp.Models;
using BlazorApp.Repositories;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        protected CompetitonRepository CompetitonRepository { get; set; }
        protected Competition Competition { get; set; } = new Competition();
        private List<Competition> Competitions { get; set; } = new List<Competition>();

        protected override async Task OnInitializedAsync()
        {
            Competitions = await CompetitonRepository.GetCompetitionsAsync();
        }
    }
}
