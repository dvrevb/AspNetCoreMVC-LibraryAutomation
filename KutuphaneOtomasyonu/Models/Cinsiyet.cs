using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public enum Cinsiyet
    {
        [Display(Name="Belirtmek İstemiyorum")]
        BelirtmekIstemiyorum=0,
        Erkek=1,
        [Display(Name = "Kadın")]
        Kadin =2
    }
}
