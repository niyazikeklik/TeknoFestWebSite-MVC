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

        public IActionResult GetAllUye()
        {
            List<Uye> Uyeler = databaseContext.Uyeler.ToList();
            return View(Uyeler);
        }

        public IActionResult BestTeams()
        {
            Random random = new Random();
            List<Takim> takimlar= new List<Takim>();
            int totalTakimSayisi=databaseContext.Takimlar.Count();
            for (int i = 0; i < 10; i++)
            {
                var randomTakim=databaseContext.Takimlar.Find(random.Next(0, totalTakimSayisi));
                if (!takimlar.Contains(randomTakim))
                {
                    takimlar.Add(randomTakim);
                }
            }
            return View();
        }

        public IActionResult GetAllTeam()
        {
            List<Takim> Takimlar = databaseContext.Takimlar.ToList();
            return View(Takimlar);
        }

        public string MembersWithoutTeamsByCategory(Alanlar alanlar)
        {
            List<Uye> MembersWithoutTeamsByCategory = (databaseContext.Uyeler.Where(x => x.TakimID == null && x.UyeAlan==alanlar)).ToList();
            string x = JsonConvert.SerializeObject(MembersWithoutTeamsByCategory);
            return x;
        }


        [HttpGet]
        public PartialViewResult GetPartialView(int PartialViewId)
        {
            return PartialView("Tab" + PartialViewId, null);
        }

        
    }
}
