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
            //jason tipinde string gelen üye idyi cümlede ayıklayıp üye tipine dönüştürüp yeni bir takım ekledim.
            TakimResult x = JsonConvert.DeserializeObject<TakimResult>(Model);//modelı takim result tipine ceviriyorum.
            List<Uye> TakimUyeleri = new List<Uye>();
            foreach (var item in x.TakimUyeleri)
            {
                int uyeID = int.Parse(item.Split('-')[0].Trim(' '));
                Uye takimuye = databaseContext.Uyeler.First(x => x.UyeOkulNo == uyeID);
                TakimUyeleri.Add(takimuye);
            }
            databaseContext.Takimlar.Add(
                             new Takim()
                             {
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

        public IActionResult UyeRemove(int ID)
        {
            Uye uye=databaseContext.Uyeler.FirstOrDefault(x=>x.UyeOkulNo==ID);
            if (uye != null) { 
                databaseContext.Uyeler.Remove(uye);
                databaseContext.SaveChanges();
            }
            return View("Index");
        }

        public IActionResult TakimRemove(int ID)
        {
            Takim takim = databaseContext.Takimlar.Include(x=> x.TakimUyeleri).FirstOrDefault(x => x.TakimdId == ID);
            if (takim != null)
            {
                foreach (var item in takim.TakimUyeleri)
                {
                   var x =  databaseContext.Uyeler.First(y => y.UyeOkulNo == item.UyeOkulNo);
                   x.UyeTakim = null;
                }
                databaseContext.SaveChanges();
                databaseContext.Takimlar.Remove(takim);
                databaseContext.SaveChanges();
            }
            return View("Index");
        }
        public IActionResult BasvuruRemove(int ID)
        {
            Basvuru basvuru = databaseContext.Basvurular.FirstOrDefault(x => x.YarismaID == ID);
            if (basvuru != null)
            {
                databaseContext.Basvurular.Remove(basvuru);
                databaseContext.SaveChanges();
            }
            return View("Index");
        }
    }
}
