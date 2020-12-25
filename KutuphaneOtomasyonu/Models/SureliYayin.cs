using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    public class SureliYayin:Eser
    {
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
    }
}
