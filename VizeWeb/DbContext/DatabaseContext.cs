﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VizeWeb.Models;

namespace VizeWeb.DatabaseContext2
{
    public class DatabaseContext : DbContext
    {
        string connectionString = AppSetting.DBSettings.Get().SQLServer;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Takim> Takimlar { get; set; }

    }
}
