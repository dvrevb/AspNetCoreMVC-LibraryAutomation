using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class TelefonNumarasi
    {
        public int Id { get; set; }
        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$",ErrorMessage ="Lütfen geçerli bir telefon numarası giriniz")]
        public string telefonNumarasi { get; set; }
    }
}
