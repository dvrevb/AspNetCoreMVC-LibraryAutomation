using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Ayirttirilanlar
    {
        public int Id { get; set; }
        [Display(Name = "Talep Tarihi")]
        public DateTime ayirttirmaTarihi { get; set; }
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }  /// FK
        [Display(Name ="Kullanıcı")]
        public string UserId { get; set; }
        public KisiselBilgiler User { get; set; }//fk
    }
}
