using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizeWeb.Models
{
    public class Basvuru
    {
        [Key]//premier key tekrarlanamaz idendity otomatik artıyor.
        public int YarismaID { get; set; }
        public string YarismaName { get; set;}

        [ForeignKey("Takim")]  // takımların tablosunun birincil anahtarı ve başvuru ile takımlar arasında bire çok ilişkisi var. 
        public int TakimID { get; set; } //kendi otomatik atıyor.
        public Takim BasvuranTakim { get; set; }
        public DateTime BasvuruTarihi { get; set; }
    }
}
