using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChessLandPrj.Models.ViewModel
{
    public class _Aboutus
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("نام")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string fullname { set; get; }

        [Required(ErrorMessage = "*")]
        [DisplayName("عنوان ")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string title { set; get; }

        [Required(ErrorMessage = "*")]
        [DisplayName("محتوای پیام")]
        [StringLength(500, ErrorMessage = "Less than 500 characters")]
        [DataType(DataType.MultilineText)]
        public string msgcomment { set; get; }

        
        [DisplayName("ایمیل ادرس")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
           ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string commentermail { set; get; }

    }
}