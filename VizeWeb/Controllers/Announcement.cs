using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VizeWeb.business;
using VizeWeb.DatabaseContext2;

namespace VizeWeb.Controllers
{
    public class Announcement : Controller
    {
        public IActionResult Index()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            var model = databaseContext.GetAllAnnouncement();
            return View("Duyuru",model);
        }

    }
}
