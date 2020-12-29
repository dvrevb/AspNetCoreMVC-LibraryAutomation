using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Odunc
    {
        public int Id { get; set; }
        public DateTime oduncTarihi { get; set; }
        public DateTime gelecegiTarih { get; set; }
        public bool uzatilabilirMi { get; set; } = true;

        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }  /// FK
        public string userId { get; set; }
        public virtual KisiselBilgiler KisiselBilgiler { get; set; }  //fk

    }
}
