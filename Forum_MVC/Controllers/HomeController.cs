using Forum_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Forum_MVC.Data;
using Forum_MVC.Data.Entities;

namespace Forum_MVC.Controllers
{
    public class HomeController : Controller
    {
        ForumDbContext context = new ForumDbContext();

        public HomeController()
        {
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 3)
        {
            var totalPosts = context.Posts.Count();
            var posts = context.Posts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var categories = context.Categories.ToList();

            var topicOfPosts = context.TopicsOfPosts.ToList();

            MyViewModel viewModel = new MyViewModel
            {
                Posts = posts,
                Categories = categories,
                TopicOfPosts = topicOfPosts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPosts = totalPosts
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}