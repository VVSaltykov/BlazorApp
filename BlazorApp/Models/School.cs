﻿namespace BlazorApp.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
