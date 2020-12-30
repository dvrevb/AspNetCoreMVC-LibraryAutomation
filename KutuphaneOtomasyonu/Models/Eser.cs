using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Eser
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        [Display(Name ="Eser Adı")]
        public string EserAdi { get; set; }
        [Display(Name = "Baskı Sayısı")]
        public int? BaskiSayisi { get; set; }
        [Display(Name = "Sayfa Sayısı")]
        public int? SayfaSayisi { get; set; }
        [Display(Name = "Kapak Resmi")]
        public string Kapak { get; set; } // eser resmi
        [Display(Name = "Eser Hakkında Bilgi")]
        public string Icerik { get; set; }
        [Display(Name = "Tür")]
        public int TurId { get; set; }
        public Tur Tur { get; set; }//FK
        
        public int YayineviId { get; set; }
        [Display(Name = "Yayınevi Adı")]
        public Yayinevi Yayinevi { get; set; } // FK
        
        public int DilId { get; set; }
        [Display(Name = "Dil")]
        public Dil Dil { get; set; }
    }
}
