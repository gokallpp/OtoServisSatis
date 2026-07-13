using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Arac : IEntity 
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0}Boş Bırakılamaz!")]
        public int MarkaId { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0}Boş Bırakılamaz!")]
        public string Renk { get; set; }
        [Display(Name = "Fiyatı")]
        public decimal Fiyat { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0}Boş Bırakılamaz!")]
        public string Modeli { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0}Boş Bırakılamaz!")]
        [Display(Name = "Kasa Tipi")]
        public string KasaTipi { get; set; }
        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; }
        [Display(Name = "Satışta mı?")]
        public bool SatistaMi { get; set; }
        [Required(ErrorMessage = "{0}Boş Bırakılamaz!")]
        public string Notlar { get; set; } // Araç ile ilgili ek bilgiler için bir alan
        public Marka? Marka { get; set; } 
    }
    
}
