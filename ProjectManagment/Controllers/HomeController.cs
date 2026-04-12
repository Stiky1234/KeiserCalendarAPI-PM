using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectManagment.Models;
using ProjectManagment.ViewModels;

namespace ProjectManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("DashboardFlow", BuildDashboardViewModel());
        }

        public IActionResult EventDetails(int id)
        {
            var dashboard = BuildDashboardViewModel();
            var calendarEvent = dashboard.Events.FirstOrDefault(e => e.Id == id) ?? dashboard.Events.First();

            return View(new EventDetailsViewModel
            {
                OrganizationName = dashboard.OrganizationName,
                Event = calendarEvent
            });
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

        private static HomeDashboardViewModel BuildDashboardViewModel()
        {
            return new HomeDashboardViewModel
            {
                OrganizationName = "Ding! Your Calendar",
                LoginHint = "Use your company or university email to sign in.",
                Events =
                [
                    new EventDashboardItem
                    {
                        Id = 1,
                        Title = "Innovation Kickoff",
                        Description = "A high-energy welcome session for new students, staff, and partners with project previews, networking, and event sign-up stations.",
                        Location = "Atrium Hall",
                        Category = "Featured",
                        Audience = "All campuses",
                        EventDate = new DateTime(2026, 4, 8),
                        StartTime = new TimeSpan(9, 0, 0),
                        EndTime = new TimeSpan(11, 0, 0),
                        Featured = true
                    },
                    new EventDashboardItem
                    {
                        Id = 2,
                        Title = "Career Connections Fair",
                        Description = "Meet company recruiters, submit resumes, and book 1:1 mentoring slots with partner organizations.",
                        Location = "Main Conference Center",
                        Category = "Career",
                        Audience = "Students and alumni",
                        EventDate = new DateTime(2026, 4, 10),
                        StartTime = new TimeSpan(13, 30, 0),
                        EndTime = new TimeSpan(16, 30, 0)
                    },
                    new EventDashboardItem
                    {
                        Id = 3,
                        Title = "Robotics Lab Demo",
                        Description = "A hands-on demonstration of autonomous prototypes, sensor kits, and student capstone builds.",
                        Location = "Engineering Lab 3",
                        Category = "Academic",
                        Audience = "Engineering programs",
                        EventDate = new DateTime(2026, 4, 12),
                        StartTime = new TimeSpan(15, 0, 0),
                        EndTime = new TimeSpan(17, 0, 0)
                    }
                ]
            };
        }
    }
}
