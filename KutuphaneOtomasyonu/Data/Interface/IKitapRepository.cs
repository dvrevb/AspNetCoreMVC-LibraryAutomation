using KutuphaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Data.Interface
{
    interface IKitapRepository
    {
        IEnumerable<Kitap> Kitaplar { get; }
        IEnumerable<Kitap> RaftakiKitaplar { get; }
        Kitap GetKitapById(int kitapId);
    }
}
