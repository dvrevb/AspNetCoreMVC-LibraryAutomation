using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KutuphaneOtomasyonu.Data
{
    public class ApplicationDbContext : IdentityDbContext<KisiselBilgiler>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Dil> Dil { get; set; }        
        public DbSet<Kitap> Kitap { get; set; }
        public DbSet<SureliYayin> SureliYayin { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Yayinevi> Yayinevi { get; set; }
        public DbSet<Yazar> Yazar { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Odunc>Odunc { get; set; }
        public DbSet<Ayirttirilanlar> Ayirttirilanlar { get; set; }
        public DbSet<KutuphaneOtomasyonu.Models.Raf> Raf { get; set; }
    }
}
