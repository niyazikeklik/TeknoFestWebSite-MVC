using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VizeWeb.Business;
using VizeWeb.DatabaseContext2;
using VizeWeb.Models;

namespace VizeWeb.business
{

    public static class Business
    {
 
        public static Tuple<List<string>, List<List<string>>> TableUyeModelCreate(List<Uye> uyeler)
        {
            var x = typeof(Uye).GetProperties().ToList();
            var y = x.Select(x => x.Name).ToList();
            y.Remove("TakimID");
            List<string> Sutunlar = new List<string>(y);
            List<List<string>> Satirlar = new();
            foreach (var item in uyeler)
            {
                List<string> Satir = new() {
                    item.UyeOkulNo.ToString(),
                    item.UyeAdi,
                    item.UyeTelNo,
                    item.UyeMail,
                    item.UyeDogumTarihi.ToShortDateString(),
                    item.UyeAlan.ToString(),
                    item.UyeTakim?.Name,

                };
                Satirlar.Add(Satir);
            }
            var model = new Tuple<List<string>, List<List<string>>>(Sutunlar, Satirlar);
            return model;
        }
        public static Tuple<List<string>, List<List<string>>> TableTakimModelCreate()
        {
            var x = typeof(Takim).GetProperties().ToList();
            var y = x.Select(x => x.Name);
            List<string> Sutunlar = new List<string>(y);
            List<List<string>> Satirlar = new();
            foreach (var item in TakimDTO.AllTeamWithMembers(new DatabaseContext()))
            {
                string takimUyeleriHTML = "";
                foreach (var itemUye in item.TakimUyeleri)
                {
                    takimUyeleriHTML += itemUye.UyeAdi + " - " + itemUye.UyeAlan + " | ";
                }

                List<string> Satir = new() {
                    item.TakimdId.ToString(),
                    item.Name,
                    item.TakimUyeleri.Count().ToString(),
                    takimUyeleriHTML,
                };
                Satirlar.Add(Satir);
            }
            var model = new Tuple<List<string>, List<List<string>>>(Sutunlar, Satirlar);
            return model;
        }

        public static Tuple<List<string>, List<List<string>>> TableBasvurularModelCreate()
        {
            var x = typeof(Basvuru).GetProperties().ToList();
            var y = x.Select(x => x.Name).ToList();
            y.Remove("TakimID");
            List<string> Sutunlar = new List<string>(y);
            List<List<string>> Satirlar = new();
            foreach (var item in BasvuruDTO.GetAllBasvuruWithTakim(new DatabaseContext()))
            {
                List<string> Satir = new() {
                    item.YarismaID.ToString(),
                    item.YarismaName,
                    item.BasvuranTakim.Name,
                    item.BasvuruTarihi.ToShortDateString(),
                };
                Satirlar.Add(Satir);
            }
            var model = new Tuple<List<string>, List<List<string>>>(Sutunlar, Satirlar);
            return model;
        }
    }
}
