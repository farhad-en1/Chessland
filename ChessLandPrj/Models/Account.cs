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
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("نام کاربری")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "کاراکتر غیرمجاز")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر"),MinLength(4,ErrorMessage = "حداقل 4 کاراکتر")]
        public virtual string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("ایمیل ادرس")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "فرمت ایمیل غلط")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر"),MinLength(8,ErrorMessage = "حداقل 8 کاراکتر")]
        public  string Email { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("گذرواژه")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "کاراکتر غیرمجاز")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر"),MinLength(5,ErrorMessage = "حداقل 5 کاراکتر")]

        public virtual string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = " کاراکتر غیرمجاز")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "همخوانی ندارد")]
        [Display(Name = "تکرار گذرواژه")]
        [MaxLength(20,ErrorMessage = "جداکثر 20 کاراکتر"),MinLength(4,ErrorMessage = "حداقل 4 کاراکتر")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("نام")]
        [MaxLength(100, ErrorMessage = "حداکثر 50 کاراکتر"),MinLength(4,ErrorMessage = "حداقل 4 حرف لازم است")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName(" نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر"),MinLength(4,ErrorMessage = "حداقل 4 حرف")]

        public string LastName { get; set; }

        [DisplayName("شماره موبایل")]
        [MaxLength(12, ErrorMessage = "مثال : 989123456789"), MinLength(12, ErrorMessage = "مثال : 989123456789")]
        public string MobilePhone { get; set; }


        public virtual City City { get; set; }

        [Display(Name = "جنسیت")]
        [UIHint("GenderOption")]
        public byte? Gender { get; set; }

        
        public bool Enable { get; set; }
        
        public DateTime LastLoginTime { get; set; }

        public ICollection<TicketQstion> Qstions { get; set; }

    }
}