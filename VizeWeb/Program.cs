using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (DatabaseContext client = new())
            {
                client.Database.Migrate();
            }
            DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Uyeler.AddRange(
                new List<Uye> {
                    new Uye()
                        {
                            UyeAdi="Niyazi",
                            UyeOkulNo=10,
                            UyeAlan=Alanlar.Backend,
                            UyeDogumTarihi=new DateTime(1999,5,6),
                            UyeMail="niyazikeklik@gmail.com",
                            UyeTelNo="0534444",
                           
                        },
                    new Uye()
                        {
                            UyeAdi="Abdullah",
                            UyeOkulNo=11,
                            UyeAlan=Alanlar.TakimLideri,
                            UyeDogumTarihi=new DateTime(2000,5,6),
                            UyeMail="abdullah@gmail.com",
                            UyeTelNo="05344444",
                        },
                    new Uye()
                        {
                            UyeAdi="Ýrem",
                            UyeOkulNo=12,
                            UyeAlan=Alanlar.Tasarim,
                            UyeDogumTarihi=new DateTime(2001,5,6),
                            UyeMail="irem@gmail.com",
                            UyeTelNo="05344444444",
                        },
                    new Uye()
                        {
                            UyeAdi="Ahmet",
                            UyeOkulNo=13,
                            UyeAlan=Alanlar.Sozcu,
                            UyeDogumTarihi=new DateTime(1999,5,6),
                            UyeMail="Ahmet@gmail.com",
                            UyeTelNo="05344444444",
                          
                        },
                    new Uye()
                        {
                            UyeAdi="Esma",
                            UyeOkulNo=14,
                            UyeAlan=Alanlar.FrontEnd,
                            UyeDogumTarihi=new DateTime(1999,5,6),
                            UyeMail="Esma@gmail.com",
                            UyeTelNo="053444554",
                        },
                });
            databaseContext.SaveChanges();
            databaseContext.Takimlar.AddRange(
                new List<Takim>{
                new Takim()
                {
                    Name="BitirimÜçlü",
                    TakimUyeleri = new List<Uye> {
                        databaseContext.Uyeler.FirstOrDefault(x=>x.UyeAdi.StartsWith("N")),
                        databaseContext.Uyeler.FirstOrDefault(x=>x.UyeAdi.StartsWith("A")),
                        databaseContext.Uyeler.FirstOrDefault(x=>x.UyeAdi.StartsWith("Ý")),
                    },
                    TakimUyeSayisi=3,
                },
            }) ;
            databaseContext.SaveChanges();

            databaseContext.Takimlar.Where(x => x.TakimdId == 1).Include(x => x.TakimUyeleri);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
