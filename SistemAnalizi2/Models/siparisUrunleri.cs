namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("siparisUrunleri")]
    public partial class siparisUrunleri
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int siparisUrunleriID { get; set; }

        [StringLength(45)]
        public string adet { get; set; }

        public int urunler_urunlerID { get; set; }

        public int siparisler_siparislerID { get; set; }

        public virtual siparisler siparisler { get; set; }

        public virtual urunler urunler { get; set; }
    }
}
