namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class adre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adresID { get; set; }

        [StringLength(45)]
        public string adresTipi { get; set; }

        [StringLength(45)]
        public string adres { get; set; }

        public int musteriler_musterilerID { get; set; }

        public int ilceler_ilcelerID { get; set; }

        public virtual ilceler ilceler { get; set; }

        public virtual musteriler musteriler { get; set; }
    }
}
