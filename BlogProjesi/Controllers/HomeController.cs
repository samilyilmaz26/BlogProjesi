using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogProjesi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //ISession _session;

        public HomeController(ILogger<HomeController> logger  )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var value = _session.GetString("username");
            //if (value != null)
            //{
            //    ViewBag.UserName = JsonConvert.DeserializeObject<string>(value);
            //}
            return View();
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
