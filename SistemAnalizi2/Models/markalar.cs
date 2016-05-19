namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("markalar")]
    public partial class markalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public markalar()
        {
            urunlers = new HashSet<urunler>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int markaID { get; set; }

        [StringLength(45)]
        public string markaAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<urunler> urunlers { get; set; }
    }
}
