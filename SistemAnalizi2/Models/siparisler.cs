namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("siparisler")]
    public partial class siparisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public siparisler()
        {
            siparisUrunleris = new HashSet<siparisUrunleri>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int siparislerID { get; set; }

        [StringLength(45)]
        public string toplamFiyat { get; set; }

        public int musteriler_musterilerID { get; set; }

        public int odemeTurleri_odemeTurleriID { get; set; }

        public int siparisTakibi_kargolamaID { get; set; }

        public virtual musteriler musteriler { get; set; }

        public virtual odemeTurleri odemeTurleri { get; set; }

        public virtual siparisTakibi siparisTakibi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<siparisUrunleri> siparisUrunleris { get; set; }
    }
}
