using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ChessLandPrj.Models;

namespace ChessLandPrj.Mapping
{
    public class CityConfig:EntityTypeConfiguration<City>
    {
        public CityConfig()
        {
            
        }
    }
}