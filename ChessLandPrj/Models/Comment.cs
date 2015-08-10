using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChessLandPrj.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName(" عنوان ")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(4, ErrorMessage = "حداقل 4 حرف")]
       
        public string  ComTitlle { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("متن ")]
        [StringLength(500, ErrorMessage = "حداکثر 500 کاراکتر"), MinLength(10, ErrorMessage = "حداقل 10 حرف")]

        public string ComContent { get; set; }

         [HiddenInput]
        public DateTime ComTime { get; set; }

        public CommeterInfo Cominfo { get; set; }

        public Comment()
        {
            Cominfo=new CommeterInfo();
        }

    }
}