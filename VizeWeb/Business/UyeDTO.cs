using System.Collections.Generic;
using System.Linq;

using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb.business
{
    public static class UyeDTO
    {
        public static List<Uye> GetAllUye(this DatabaseContext databaseContext)
        {
            List<Uye> Uyeler = databaseContext.Uyeler.ToList();
            return Uyeler;
        }

        public static List<Uye> MembersWithoutTeamsByCategory(this DatabaseContext databaseContext, Alanlar alanlar)
        {
            List<Uye> MembersWithoutTeamsByCategory = (databaseContext.Uyeler.Where(x => x.TakimID == null && x.UyeAlan == alanlar)).ToList();
            return MembersWithoutTeamsByCategory;
        }
        public static IQueryable<Uye> NonTeamMembers(this DatabaseContext databaseContext)
        {
            var NonTeamMembers = (databaseContext.Uyeler.Where(x => x.TakimID == null));
            return NonTeamMembers;
        }


    }
}
