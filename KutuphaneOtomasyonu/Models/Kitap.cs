using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Kitap:Eser
    {

        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        public bool OduncDurumu { get; set; } = false;


    }
}
