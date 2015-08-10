using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChessLandPrj.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [MaxLength(50)]
        public string CountryName { get; set; }

        public string LatinName { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}