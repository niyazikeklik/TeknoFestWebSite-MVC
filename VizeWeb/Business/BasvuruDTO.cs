using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb.Business
{
    public static class BasvuruDTO
    {
        public static List<Basvuru> GetAllBasvuruWithTakim(this DatabaseContext databaseContext)
        {
           return databaseContext.Basvurular.Include(x=> x.BasvuranTakim).ToList();
        }
    }
}
