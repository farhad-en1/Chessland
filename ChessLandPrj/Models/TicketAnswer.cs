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
    public class TicketAnswer
    {
        [Key]
        public int AnsId { set; get; }

        [Required(ErrorMessage = "*")]
        [DisplayName(" پاسخ شما : ")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر"), MinLength(10, ErrorMessage = "حداقل 10 حرف")]

        public string AnsContent { set; get; }

        [HiddenInput]
        public DateTime? AnsReTime { set; get; }

        
        public virtual TicketQstion TicketQstion { set; get; }

    }
}