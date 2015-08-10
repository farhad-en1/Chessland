using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ChessLandPrj.Models
{
    public class TicketQstion
    {
        [Key]
        public int QstionId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName(" عنوان پرسش")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(4, ErrorMessage = "حداقل 4 حرف")]
        public string QstionTitle { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("متن پرسش")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر"), MinLength(10, ErrorMessage = "حداقل 10 حرف")]

        public string QstionContent { get; set; }

        [HiddenInput]
        public DateTime RegTime { get; set; }

        [ForeignKey("FkAccountId")]
        public virtual Account Acc { get; set; }
        public int FkAccountId { get; set; }

        
        public virtual TicketAnswer TicketAnswer { get; set; }


    }
}