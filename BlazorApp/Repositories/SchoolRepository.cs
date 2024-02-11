using BlazorApp.Models;

namespace BlazorApp.Repositories
{
    public class SchoolRepository
    {
        private readonly ApplicationContext applicationContext;

        public SchoolRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<List<School>> GetSchoolsAsync()
        {
            var schools = applicationContext.Schools.ToList();
            return schools;
        }
    }
}
