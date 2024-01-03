using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavTekrar.Models
{
    [Table("Ogrenciler")]
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public string Ad { get; set; }

        [Required]
        [MaxLength(50)]
        public string Soyad { get; set; }

        [Required]
        [MaxLength(50)]
        public string Numara { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tarih { get; set; }

        [Required]
        [MaxLength(50)]
        public string Adres { get; set; }
    }
}
