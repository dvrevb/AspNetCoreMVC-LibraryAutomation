using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class EPostaAdresi
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage="LÜtfen geçerli bir mail adresi girin")]
        public string epostaAdresi { get; set; }
    }
}
