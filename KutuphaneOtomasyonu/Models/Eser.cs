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
        [StringLength(13,MinimumLength =13,ErrorMessage ="ISBN 13 hane olmalıdır")]
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
        [Display(Name = "Yayınevi")]
        public int YayineviId { get; set; }
        public Yayinevi Yayinevi { get; set; } // FK
        [Display(Name = "Dil")]
        public int DilId { get; set; }
        public Dil Dil { get; set; }
        [Display(Name = "Raf")]
        public int RafId { get; set; }
        public Raf Raf { get; set; }   ///fk
    }
}
