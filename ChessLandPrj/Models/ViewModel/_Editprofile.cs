using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChessLandPrj.Models.ViewModel
{
    public class _Editprofile
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("نام")]
        [MaxLength(100, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(4, ErrorMessage = "حداقل 4 حرف لازم است")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName(" نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(4, ErrorMessage = "حداقل 4 حرف")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("ایمیل ادرس")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "فرمت ایمیل غلط")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(8, ErrorMessage = "حداقل 8 کاراکتر")]
        public string Email { get; set; }

        [Display(Name = "جنسیت")]
        [UIHint("GenderOption")]
        public byte? Gender { get; set; }

    }
}