using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Kitap:Eser
    {
        [Display(Name ="Yazar Ad Soyad")]
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        [Display(Name = "Ödünç Alınmış mı?")]
        public bool OduncDurumu { get; set; } = false;
    }
}
