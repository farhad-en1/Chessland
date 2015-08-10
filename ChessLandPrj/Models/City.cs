using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChessLandPrj.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        [ForeignKey("FkProvinceId")]
        public virtual Province Prov { get; set; }
        public int FkProvinceId { get; set; }

        
    }
}