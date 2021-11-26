
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VizeWeb.Models
{

    public class DBSettings
    {

        private static DBSettings instance;

        public static DBSettings Ins
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBSettings();
                }
                return instance;
            }
        }
        private DBSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, true)
           .AddJsonFile("appsettings.Development.json", true, true)
           .Build();
            instance = configuration.GetSection("DBSettings")
               .Get<DBSettings>();
        }
        public string SQLServer { get; set; }



    }
}
