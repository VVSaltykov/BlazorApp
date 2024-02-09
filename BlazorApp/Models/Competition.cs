namespace BlazorApp.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public List<User>? Users { get; set; }
    }
}
