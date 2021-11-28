using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizeWeb.Models
{
    public class Basvuru
    {
        [Key]
        public int YarismaID { get; set; }
        public string YarismaName { get; set;}

        [ForeignKey("Takim")]
        public int TakimID { get; set; }
        public Takim BasvuranTakim { get; set; }
        public DateTime BasvuruTarihi { get; set; }
    }
}
