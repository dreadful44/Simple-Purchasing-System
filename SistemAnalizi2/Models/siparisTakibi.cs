namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("siparisTakibi")]
    public partial class siparisTakibi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public siparisTakibi()
        {
            siparislers = new HashSet<siparisler>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kargolamaID { get; set; }

        [StringLength(45)]
        public string siparisDurumu { get; set; }

        [StringLength(45)]
        public string siparisTarihi { get; set; }

        [StringLength(45)]
        public string tahminiTeslimTarihi { get; set; }

        [StringLength(45)]
        public string teslimTarihi { get; set; }

        public int KargoFirmalari_KargoFirmalariID { get; set; }

        public virtual kargoFirmalari kargoFirmalari { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<siparisler> siparislers { get; set; }
    }
}
