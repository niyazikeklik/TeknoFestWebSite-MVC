using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizeWeb.Models
{
    public class Uye
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//idendity yok elle girilecek.
        [Required]//boş geçilemez.
        [Key]
        public int UyeOkulNo { get; set; }
        public string UyeAdi { get; set; }
        public string UyeTelNo { get; set; }
        public string UyeMail { get; set; }
        public DateTime UyeDogumTarihi { get; set; }
        public Alanlar UyeAlan { get; set; }
#nullable enable
        [ForeignKey("Takim")]
        public int? TakimID { get; set; }
        public Takim? UyeTakim { get; set; }
#nullable disable
   
   
    }
}
