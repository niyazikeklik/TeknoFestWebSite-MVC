using System.Collections.Generic;
using System;
using VizeWeb.DatabaseContext2;
using VizeWeb.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VizeWeb.business
{
    public static class TakimDTO
    {
        public static List<Takim> MembersByTeam(this DatabaseContext databaseContext, int takimID)
        {
            return databaseContext.Takimlar.Where(x => x.TakimdId == takimID).Include(x => x.TakimUyeleri).ToList();
        }
        public static List<Takim> AllTeamWithMembers(this DatabaseContext databaseContext)
        {
            return databaseContext.Takimlar.Where(x => true).Include(x => x.TakimUyeleri).ToList();
        }
        public static List<Takim> GetAllTeam(this DatabaseContext databaseContext)
        {
            List<Takim> Takimlar = databaseContext.Takimlar.ToList();
            return Takimlar;
        }
        public static List<Takim> BestTeams(this DatabaseContext databaseContext)
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
    }
}
