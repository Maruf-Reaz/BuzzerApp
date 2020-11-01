using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IspahaniBuzzerApp.Models;
using Dynamo.Model.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Dynamo.Data;

namespace IspahaniBuzzerApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
           
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing
            ViewData["UserId"] = userId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Buzzer()
        {
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing
            ViewData["UserId"] = userId;
            return View();
        }

        public IActionResult StartView(int examId)
        {
            ViewData["ExamId"] = examId;
            return View();

        }

     
        public async Task<IActionResult> Mcq(int examId)
        {
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing
           
            var exam = _context.Exams.Where(m => m.Id == examId).FirstOrDefault();
            var questions = _context.Questions.Where(m => m.ExamId == examId).ToList();

            //private static Random rng = new Random();

            //public static void Shuffle<T>(this IList<T> list)
            //{
            //    int n = list.Count;
            //    while (n > 1)
            //    {
            //        n--;
            //        int k = rng.Next(n + 1);
            //        T value = list[k];
            //        list[k] = list[n];
            //        list[n] = value;
            //    }
            //}




            ViewData["Questions"] = questions;
            ViewData["Exam"] = exam;
            ViewData["UserId"] = userId;

            return View();
        }

        public async Task<IActionResult> StopMcq(int examId)
        {
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing

            var exam = _context.Exams.Where(m => m.Id == examId).FirstOrDefault();

            ViewData["Exam"] = exam;
            ViewData["UserId"] = userId;


            return View();
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
