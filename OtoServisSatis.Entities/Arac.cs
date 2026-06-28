using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Arac : IEntity 
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        [StringLength(50)]
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        [StringLength(50)]
        public string Modeli { get; set; }
        [StringLength(50)]
        public string KasaTipi { get; set; }
        public int ModelYili { get; set; }
        public bool SatistaMi { get; set; }
        public string Notlar { get; set; } // Araç ile ilgili ek bilgiler için bir alan
        public Marka? Marka { get; set; } 
    }
    
}
