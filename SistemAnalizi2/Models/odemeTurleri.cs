namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("odemeTurleri")]
    public partial class odemeTurleri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public odemeTurleri()
        {
            siparislers = new HashSet<siparisler>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int odemeTurleriID { get; set; }

        [StringLength(45)]
        public string tipAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<siparisler> siparislers { get; set; }
    }
}
