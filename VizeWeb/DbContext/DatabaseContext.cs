using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using VizeWeb.Models;

namespace VizeWeb.DatabaseContext2
{
    public class DatabaseContext : DbContext
    {

        string connectionString = new DBSettings().Get().SQLServer;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString); // veritabanının yolunu belirliyoruz.
        }
        public DbSet<Uye> Uyeler { get; set; } //tabloyu simgeliyor.
        public DbSet<Takim> Takimlar { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Basvuru> Basvurular { get; set; }
    }

}
