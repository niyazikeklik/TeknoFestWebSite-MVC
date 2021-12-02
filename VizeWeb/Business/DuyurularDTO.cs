using System.Collections.Generic;
using System.Linq;

using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb.business
{
    public static class DuyurularDTO
    {
        public static void AddAnnouncement(this DatabaseContext databaseContext, Duyuru duyurular)
        {
            databaseContext.Duyurular.Add(duyurular);
            databaseContext.SaveChanges();
        }
        public static List<Duyuru> GetAllAnnouncement(this DatabaseContext databaseContext)
        {
            return databaseContext.Duyurular.ToList();
        }
        public static List<Duyuru> FiveAnnouncements(this DatabaseContext databaseContext)
        {
            return databaseContext.Duyurular.OrderByDescending(x => x.DuyuruTarihi).Take(5).ToList();
        }
    }
}
