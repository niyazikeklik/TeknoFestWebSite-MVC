using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizeWeb.Models
{
    public class Takim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TakimdId { get; set; }
        public string Name { get; set; }
        public int TakimUyeSayisi { get; set; }
        public string  OkulName { get; set; }
        public ICollection<Uye> TakimUyeleri { get; set; }

    }
}
