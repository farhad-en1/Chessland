using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChessLandPrj.Models.ViewModel
{
    public class _Login
    {

        [Required(ErrorMessage = "*")]
        [DisplayName("نام کاربری")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "کاراکتر غیرمجاز")]
        public  string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("گذرواژه")]

        public string Password { get; set; }
    }
}