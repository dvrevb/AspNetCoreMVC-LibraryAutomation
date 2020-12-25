using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class Eser
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string EserAdi { get; set; }
        public int? BaskiSayisi { get; set; }
        public int? SayfaSayisi { get; set; }
        public string Kapak { get; set; } // eser resmi
        public string Icerik { get; set; }

        public int TurId { get; set; }
        public Tur Tur { get; set; }//FK

        public int YayineviId { get; set; }
        public Yayinevi Yayinevi { get; set; } // FK

        public int DilId { get; set; }
        public Dil Dil { get; set; }
    }
}
