using Microsoft.EntityFrameworkCore;
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
        public List<Uye> NonTeamMembers()
        {
            List<Uye> NonTeamMembers = (databaseContext.Uyeler.Where(x => x.TakimID == null)).ToList();
            return NonTeamMembers;
        }

        public List<Takim> MembersByTeam(int takimID)
        {
            return databaseContext.Takimlar.Where(x => x.TakimdId == takimID).Include(x => x.TakimUyeleri).ToList();
        }

        public List<Takim> AllTeamWithMembers(int takimID)
        {
            return databaseContext.Takimlar.Where(x => true).Include(x => x.TakimUyeleri).ToList();
        }
        public string MembersWithoutTeamsByCategory(Alanlar alanlar)
        {
            List<Uye> MembersWithoutTeamsByCategory = (databaseContext.Uyeler.Where(x => x.TakimID == null && x.UyeAlan == alanlar)).ToList();
            string x = JsonConvert.SerializeObject(MembersWithoutTeamsByCategory);
            return x;
        }
        public List<Takim> GetAllTeam()
        {
            List<Takim> Takimlar = databaseContext.Takimlar.ToList();
            return Takimlar;
        }
        public List<Takim> BestTeams()
        {
            Random random = new Random();
            List<Takim> takimlar = new List<Takim>();
            int totalTakimSayisi = databaseContext.Takimlar.Count();
            for (int i = 0; i < 10; i++)
            {
                var randomTakim = databaseContext.Takimlar.Find(random.Next(0, totalTakimSayisi));
                if (!takimlar.Contains(randomTakim))
                {
                    takimlar.Add(randomTakim);
                }
            }
            return takimlar;
        }
        public List<Uye> GetAllUye()
        {
            List<Uye> Uyeler = databaseContext.Uyeler.ToList();
            return Uyeler;
        }
    }
}
