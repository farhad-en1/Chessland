using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ChessLandPrj.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessLandPrj.Mapping
{
    public class ProvinceConfig : EntityTypeConfiguration<Province>
    {
        public ProvinceConfig()
        {
            /* relationship province and countri =>   one -many
            this.HasRequired(x => x.Country) // principle
                .WithMany(x => x.Provinces);  */
        } 
        
        
    }
}