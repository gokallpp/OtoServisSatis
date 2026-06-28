using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Kullanici : IEntity 
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool AktifMi { get; set; } // Kullanıcının aktif olup olmadığını belirten bir alan
        public DateTime? EklemeTarihi { get; set; } = DateTime.Now; // Kullanıcının sisteme eklenme tarihini saklamak için bir alan
        public int RolId { get; set; } // Kullanıcının rolünü belirten bir alan
        public Rol? Rol { get; set; }




    }
    
}
