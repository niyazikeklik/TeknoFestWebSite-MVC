using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VizeWeb.Models;

namespace VizeWeb.DatabaseContext2
{
    public class DatabaseContext : DbContext
    {
        string connectionString = @$"Data Source=.;Initial Catalog=TeknoFestOdev;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Takim> Takimlar { get; set; }

        public DbSet<Duyuru> Duyurular { get; set; }

    }
}
