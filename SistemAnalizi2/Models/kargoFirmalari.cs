namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kargoFirmalari")]
    public partial class kargoFirmalari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kargoFirmalari()
        {
            siparisTakibis = new HashSet<siparisTakibi>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kargoFirmalariID { get; set; }

        [StringLength(45)]
        public string firmaAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<siparisTakibi> siparisTakibis { get; set; }
    }
}
