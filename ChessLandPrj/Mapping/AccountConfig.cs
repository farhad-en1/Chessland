using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ChessLandPrj.Models;

namespace ChessLandPrj.Mapping
{
    public class AccountConfig:EntityTypeConfiguration<Account>
    {
        public AccountConfig()
        {
           // relatipon account with citeis many - one => account - Cites

            this.HasOptional(x => x.City)
                .WithMany(x => x.Accounts);


        }
    }
}