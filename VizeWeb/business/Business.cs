using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb.business
{
    public class Business
    {
        DatabaseContext databaseContext = new DatabaseContext();
        public void AddAnnouncement(Duyuru duyurular)
        {
            databaseContext.Duyurular.Add(duyurular);
            databaseContext.SaveChanges();
        }
        public List<Duyuru> GetAllAnnouncement()
        {
            return databaseContext.Duyurular.ToList();
        }
        public List<Duyuru> LastFiveAnnouncements()
        {
            return databaseContext.Duyurular.OrderByDescending(x=>x.DuyuruTarihi).Take(5).ToList();
        }
        public string NonTeamMembers()
        {
            List<Uye> NonTeamMembers = (databaseContext.Uyeler.Where(x => x.TakimID == null)).ToList();
            string x = JsonConvert.SerializeObject(NonTeamMembers);
            return x;
        }
    }
}
