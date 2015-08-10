using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChessLandPrj.Models
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        [MaxLength(50)]
        public string ProvinceName { get; set; }

        public virtual ICollection<City> Cities { get; set; }

         [ForeignKey("FkCountryId")]
        public virtual Country Country { get; set; }
         public int FkCountryId { get; set; }
        
    }
}