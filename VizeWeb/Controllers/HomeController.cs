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
using VizeWeb.business;
using static VizeWeb.Models.Results;

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

        [HttpGet]
        public IActionResult SignUp(Uye uye)
        {
            databaseContext.Uyeler.Add(uye);
            databaseContext.SaveChanges();
            return View("Index");
        }

     
        [HttpPost]
        public IActionResult AddTeam(string Model)
        {
            var x = JsonConvert.DeserializeObject<TakimResult>(Model);
            List<Uye> TakimUyeleri = new List<Uye>();
            foreach (var item in x.TakimUyeleri)
            {
                int uyeID = int.Parse(item.Split('-')[0].Trim(' '));
                Uye takimuye = databaseContext.Uyeler.First(x => x.UyeOkulNo == uyeID);
                TakimUyeleri.Add(takimuye);
            }
            databaseContext.Takimlar.Add(
                             new Takim() {
                                 Name = x.Name,
                                 TakimUyeleri = TakimUyeleri,
                                 TakimUyeSayisi = TakimUyeleri.Count,
                             }
                         );
            databaseContext.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public IActionResult AddBasvuru(string Model)
        {
            int TakimID = int.Parse(Model.Split('-')[1].Trim(' '));
            databaseContext.Basvurular.Add(
                             new Basvuru() {
                                 BasvuruTarihi = DateTime.Now,
                                 BasvuranTakim = databaseContext.Takimlar.First(x => x.TakimdId == TakimID),
                                 YarismaName = "Helikopter Tasarım Yarışması",
                             }
                         ); ;
            databaseContext.SaveChanges();
            return View("Index");
        }
        [HttpGet]
        public IActionResult Duyurular()
        {
            var model = new DatabaseContext().GetAllAnnouncement();
            return View("Duyurular", model);
        }
    }
}
