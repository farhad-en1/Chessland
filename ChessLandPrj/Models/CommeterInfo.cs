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
    [ComplexType]
    public class CommeterInfo
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("نام")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(4, ErrorMessage = "حداقل 4 حرف لازم است")]

        public string CommnenterFullName { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("ایمیل ادرس")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "فرمت ایمیل غلط")]
        [StringLength(50, ErrorMessage = "حداکثر 50 کاراکتر"), MinLength(8, ErrorMessage = "حداقل 8 کاراکتر")]
      
        public string CommenterMail { get; set; }
        [HiddenInput]
        [MaxLength(50)]
        public string CommenterIpAddress { get; set; }
        //this field not required , این فیلد اختیاری می باشد به خاطر همین تو رابطه ذکر نشده است
        [HiddenInput]
        public int CommeterId { get; set; }
    }
}