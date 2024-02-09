using BlazorApp.Models;

namespace BlazorApp.Repositories
{
    public class CompetitonRepository
    {
        private readonly ApplicationContext applicationContext;

        public CompetitonRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task AddCompetitionAsync()
        {

        }

        public async Task<List<Competition>> GetCompetitionsAsync()
        {
            var competitions = applicationContext.Competitions.ToList();
            return competitions;
        }
    }
}
