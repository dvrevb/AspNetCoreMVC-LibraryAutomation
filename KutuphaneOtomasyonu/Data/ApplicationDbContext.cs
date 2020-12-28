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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<KisiselBilgiler>(b =>
        //    {
        //        b.Property(u => u.Email).HasColumnName("EPostaAdresi");
        //    });
        //}

        public DbSet<Dil> Dil { get; set; }
        
       // public DbSet<KisiselBilgiler> KisiselBilgiler { get; set; }
        public DbSet<Kitap> Kitap { get; set; }
        public DbSet<SureliYayin> SureliYayin { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Yayinevi> Yayinevi { get; set; }
        public DbSet<Yazar> Yazar { get; set; }
        
    }
}
