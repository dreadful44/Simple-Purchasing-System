namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("musteriler")]
    public partial class musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public musteriler()
        {
            adres = new HashSet<adre>();
            siparislers = new HashSet<siparisler>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int musterilerID { get; set; }

        [StringLength(45)]
        public string adi { get; set; }

        [StringLength(45)]
        public string soyadi { get; set; }

        [StringLength(45)]
        public string telefon { get; set; }

        [StringLength(45)]
        public string kullaniciAdi { get; set; }

        [Required]
        [StringLength(45)]
        public string sifre { get; set; }

        [StringLength(45)]
        public string eposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<adre> adres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<siparisler> siparislers { get; set; }
    }
}
