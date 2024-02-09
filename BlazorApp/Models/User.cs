using BlazorApp.Definitions;

namespace BlazorApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public School? School { get; set; }
        public List<Competition>? Competitions { get; set; }
    }
}
