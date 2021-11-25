using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizeWeb.Models
{
    public class Takim
    {
     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TakimdId { get; set; }
        public string Name { get; set; }
        public int TakimUyeSayisi { get; set; }
        public ICollection<Uye> TakimUyeleri { get; set; }

    }
}
