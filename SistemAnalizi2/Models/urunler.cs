namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("urunler")]
    public partial class urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urunler()
        {
            siparisUrunleris = new HashSet<siparisUrunleri>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int urunlerID { get; set; }

        [StringLength(45)]
        public string urunAdi { get; set; }

        [StringLength(45)]
        public string fiyati { get; set; }

        public int markalar_markaID { get; set; }

        public int kategori_kategoriID { get; set; }

        public int stokBilgisi_stokID { get; set; }

        public virtual kategori kategori { get; set; }

        public virtual markalar markalar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<siparisUrunleri> siparisUrunleris { get; set; }

        public virtual stokBilgisi stokBilgisi { get; set; }
    }
}
