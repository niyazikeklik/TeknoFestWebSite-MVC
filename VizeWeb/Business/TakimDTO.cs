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
            return databaseContext.Takimlar.Include(x => x.TakimUyeleri).ToList();
        }
        public static List<Takim> GetAllTeam(this DatabaseContext databaseContext)
        {
            List<Takim> Takimlar = databaseContext.Takimlar.ToList();
            return Takimlar;
        }
        public static List<Takim> BestTeams(this DatabaseContext databaseContext)
        {
            Random random = new Random();
            int count = 5;
            List<Takim> takimlar = new List<Takim>();
            int totalTakimSayisi = databaseContext.Takimlar.Count();
            if (totalTakimSayisi < 5) count = totalTakimSayisi;
            for (int i = 0; i < count;)
            {
                var randomTakim = databaseContext.Takimlar.Include(x=> x.TakimUyeleri).ToList()[random.Next(0, totalTakimSayisi)];
                if (!takimlar.Contains(randomTakim))
                {
                    takimlar.Add(randomTakim);
                    i++;
                }
            }
            return takimlar;
        }
    }
}
