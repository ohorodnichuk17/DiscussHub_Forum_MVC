﻿using Forum_MVC.Data.Entities;

namespace Forum_MVC.Models
{
    public class MyViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
        public List<TopicOfPost> TopicOfPosts { get; set; }
        public int PageSize { get; set; } 
        public int PageNumber { get; set; } 
        public int TotalPosts { get; set; } 
    }

}
