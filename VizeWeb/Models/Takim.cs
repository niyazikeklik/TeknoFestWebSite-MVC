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
        public ICollection<Uye> TakimUyeleri { get; set; }// bir takımın birden cok üyesi olabilir ilişkisel tablo üyeleyle takımlar arasında bire çok ilişki.
        public ICollection<Basvuru> Yarismalar  { get; set; } //aynı şey geçerli.
    }
}
