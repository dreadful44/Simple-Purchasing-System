namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ilceler")]
    public partial class ilceler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ilceler()
        {
            adres = new HashSet<adre>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ilcelerID { get; set; }

        [StringLength(45)]
        public string ilceAdi { get; set; }

        public int iller_illerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<adre> adres { get; set; }

        public virtual iller iller { get; set; }
    }
}
