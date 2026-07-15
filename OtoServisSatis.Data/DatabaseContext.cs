using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GÖKALP\\SQLEXPRESS;Database=OtoServisSatis;Integrated Security=True;TrustServerCertificate=True;");

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Burada Fluent API kullanarak entitylerin özelliklerini yapılandırabilirsiniz
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"

            });

            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Adi = "Kullanici",
                AktifMi = true,
                EklemeTarihi = DateTime.Now,
                Email = "admin@otoservissatis.tc",
                KullaniciAdi = "admin",
                Sifre = "123456",
                RolId = 1,
                Soyadi = "admin",
                Telefon = "0850 123 45 67"

            });

        }
    }
}
