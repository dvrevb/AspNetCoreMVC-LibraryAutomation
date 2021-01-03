using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Tur
    {
        public int Id { get; set; }
        [Display(Name ="Tür Ad")]
        public string TurAd { get; set; }
    }
}
