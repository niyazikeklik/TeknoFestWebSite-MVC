using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb.business
{
    public static class Business
    {
        static DatabaseContext  databaseContext = new DatabaseContext();
        public static void AddAnnouncement(Duyuru duyurular)
        {
            databaseContext.Duyurular.Add(duyurular);
            databaseContext.SaveChanges();
        }
        public static List<Duyuru> GetAllAnnouncement()
        {
            return databaseContext.Duyurular.ToList();
        }
        public static List<Duyuru> LastFiveAnnouncements()
        {
            return databaseContext.Duyurular.OrderByDescending(x=>x.DuyuruTarihi).Take(5).ToList();
        }
        public static List<Uye> NonTeamMembers()
        {
            List<Uye> NonTeamMembers = (databaseContext.Uyeler.Where(x => x.TakimID == null)).ToList();
            return NonTeamMembers;
           
        }
    }
}
