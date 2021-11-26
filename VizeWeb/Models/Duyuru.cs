using System;
using System.ComponentModel.DataAnnotations;

namespace VizeWeb.Models
{
    public class Duyuru
    {
        [Key]
        public int DuyuruID { get; set; }
        public string DuyuruBaslik { get; set; }
        public string DuyuruAciklama { get; set; }
        public string DuyuruDetayLink { get; set; }
        public DateTime DuyuruTarihi { get; set; }
    }
}
