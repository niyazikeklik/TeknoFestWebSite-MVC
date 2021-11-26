using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VizeWeb.DatabaseContext2;
using VizeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace VizeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DatabaseContext databaseContext = new DatabaseContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Uye uye)
        {
            databaseContext.Uyeler.Add(uye);
            databaseContext.SaveChanges();
            return View();
        }

        public IActionResult AddTeam(Takim takim)
        {
            databaseContext.Takimlar.Add(takim);
            databaseContext.SaveChanges();
            return View();
        }

        public PartialViewResult GetPartialView(int PartialViewId)
        {
            return PartialView("Tab" + PartialViewId, null);
        }

        
    }
}
