namespace SistemAnalizi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yoneticiler")]
    public partial class yoneticiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int yoneticilerID { get; set; }

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
    }
}
