﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VizeWeb.Models
{
    public class AppSetting
    {
        public class DBSettings
        {
            public string SQLServer { get; set; }

            public static DBSettings Get()
            {
                IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .AddJsonFile("appsettings.Development.json", true, true)
               .Build();
                return configuration.GetSection("DBSettings")
                   .Get<DBSettings>();
            }

        }
    }
}
