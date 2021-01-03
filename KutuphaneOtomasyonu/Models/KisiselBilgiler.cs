using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class KisiselBilgiler:IdentityUser
    {
     
        [StringLength(30, MinimumLength = 2,ErrorMessage ="Ad alanına en az 2 en fazla 30 karakter girebilirsiniz")]
        public string Ad { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Soyad alanına en az 2 en fazla 30 karakter girebilirsiniz")]
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DogumTarihi { get; set; }
     
    }
}
