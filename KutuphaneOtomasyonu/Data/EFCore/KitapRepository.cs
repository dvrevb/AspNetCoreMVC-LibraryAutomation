using KutuphaneOtomasyonu.Data.Interface;
using KutuphaneOtomasyonu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Data.EFCore
{
    class KitapRepository : IKitapRepository
    {
        ApplicationDbContext _db;
        public KitapRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Kitap> Kitaplar => _db.Kitap.Include(c => c.Tur)
            .Include(y => y.Yayinevi);   //Kitaplari getir.
          
        public IEnumerable<Kitap> RaftakiKitaplar => _db.Kitap.Where(p=>p.OduncDurumu==false)
            .Include(c => c.Tur)
            .Include(y => y.Yayinevi);   // raftaki kitaplari getir.

        public Kitap GetKitapById(int kitapId)
        {
            return _db.Kitap.FirstOrDefault(x => x.Id == kitapId);
            
        }
    }
    
}
