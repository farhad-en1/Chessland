using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ChessLandPrj.Models;

namespace ChessLandPrj.Mapping
{
    public class TicketQstionConfig:EntityTypeConfiguration<TicketQstion>
    {
        public TicketQstionConfig()
        {
            // one - one Qstion and Answer
            this.HasOptional(x => x.TicketAnswer)  // answer is dependent
                .WithRequired(x=>x.TicketQstion) // qstion is princple  وقتی پرسش حذف شد پاسخ هم حذف شود 
                .WillCascadeOnDelete();

            // one - many  Qstion and account 
           this.HasRequired(x=>x.Acc) // account is principle 
               .WithMany(x=>x.Qstions) // qstion is dependent
               .WillCascadeOnDelete();

        }
    }
}