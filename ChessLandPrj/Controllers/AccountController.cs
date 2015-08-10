using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessLandPrj.BenfitClass;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;
using ChessLandPrj.Models.ViewModel;
using ChessLandPrj.Service;

namespace ChessLandPrj.Controllers
{

    public class AccountController : Controller
    {
        readonly IAccount _accountService;
        readonly ICountry _countryService;
        readonly IProvince _provinceService;
        readonly ICity _cityService;
        private readonly IComment _commentService;
        readonly IUnitOfWork _uow;
        //
        // GET: /Account/
        public AccountController(IUnitOfWork uow, IAccount accountService, ICountry countryService, IProvince provinceService, ICity cityService, IComment commentService)
        {
            _accountService = accountService;
            _countryService = countryService;
            _provinceService = provinceService;
            _cityService = cityService;
            _commentService = commentService;
            _uow = uow;
        }


        public ActionResult Index()
        {
            return PartialView("_Signup");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CreateAccount(Account account)
        {
            if (ModelState.IsValid)
            {
                // check if cites exist and get prov and country
                
                if (account.City!=null && account.City.CityId != null)
                {
                    var cityinfo = _cityService.GetCityById(account.City.CityId);
                   if (cityinfo == null)
                    {
                        return  Json(new { Valid = false, Error = GetErrorsFromModelState(1,"اطلاعات ارسالی درست نمی باشد ") });; // citys not exist problem in system
                    }
                    account.City = cityinfo;
                }
                // if username is valid
                var wSession = new WorkSession();
                if (wSession.IsLoginUser()) return Json(new { Valid = false, Error = GetErrorsFromModelState(2, "شما در حال حاضر یک حساب کاربری دارید") }); ;
                if (_accountService.AccountNameExist(account.UserName, account.Email)) return Json(new { Valid = false, Error = GetErrorsFromModelState(2, "این نام کاربری قبلا در سیستم وجود دارد") }); ; // username or email exist in DB

                account.Enable = true;
                account.LastLoginTime = DateTime.Now;
                _accountService.AddNewAccount(account);
                try
                {
                    _uow.SaveChanges();
                    return Json(new { Valid = ModelState.IsValid, Error = GetErrorsFromModelState(3, "سیستم کاربری با موفقیت برای شما ایجاد شد") }); ;
                }
                catch
                {
                    return Json(new { Valid = false, Error = GetErrorsFromModelState(2, "خطایی در هنگام ذخیره اطلاعات رخ داده است لطفا پس از مدتی دوباره تلاش فرمایید") }); ; // error in save account

                }
                
            }
            return Json(new { Valid = ModelState.IsValid, Error = GetErrorsFromModelState(1, "اطلاعات ارسالی درست نمی باشد") }); ;
        }

        // for login page 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return PartialView("_Login");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Signin( _Login infoLogin)
        {
            if (Session["user"] != null)
            {
                return Json(new { Valid = false, message = "شما در حاضر وارد سیستم هستید" });
            }
            
            if (!ModelState.IsValid) return Json(new { Valid = false, message = "اطلاعات فرستاده شده غلط می باشد" });

           var acc= _accountService.LoginAcocunt(infoLogin.UserName, infoLogin.Password);
           if (acc == null) return Json(new { Valid = false, message = "اطلاعات فرستاده شده غلط می باشد" });
           Session.Add("user", acc.AccountId);
           string sex = acc.Gender == 1 ? "اقای" : "خانم ";
           Session.Add("welcome", sex + " " + acc.FirstName + " " + acc.LastName);

           return Json(new { Valid = true, message = Session["welcome"] + " " + " خوش آمدید" });
            
        }



        // for editing profile
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditProfile()
        {
            if (Session["user"] != null)
            {
                int iduser;
                if (Int32.TryParse(Session["user"].ToString(), out iduser))
                {
                    var acc=_accountService.GetInfoAccount(iduser);
                    var accedit = new _Editprofile()
                    {
                        Email = acc.Email,
                        FirstName = acc.FirstName,
                        Gender = acc.Gender,
                        LastName = acc.LastName
                    };
                    return PartialView("_EditProfile",accedit);
                }
            }
            ViewBag.message = "شما برای دسترسی به قسمت ویرایش اطلاعات ابتدا باید وارد حساب کاربری خود شوید";
            return PartialView("_NotLogin");

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditProfile(_Editprofile _editprofile)
        {
            if (!ModelState.IsValid) return Json(new { Valid = false, message = "اطلاعات ارسالی درست نیست" });
            var ws=new WorkSession();
            if (!ws.IsLoginUser()) return Json(new { Valid = false, message = "شما برای ویرایش اطلاعات باید وارد سیستم شوید" });
            if(_accountService.EditAccount(_editprofile,ws.GetId()))
            return Json(new { Valid = true, message = " اطلاعات شما با موفقیت ویرایش گردید ", data = Session["welcome"] + " " + " خوش آمدید" });
            return Json(new { Valid = false, message = "خطایی در هنگام ویرایش اطلاعات رخ داده است" });
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetProvibyCountryId(string  id)
        {
            int cId;
            bool valid = Int32.TryParse(id, out cId);
            IList<Province> result = null;
            if (valid)
            {
                result = _provinceService.GetProvinceByCountryId(cId);
            }
            return result != null ? Json(result.Select(x=> new {x.ProvinceId,x.ProvinceName}), JsonRequestBehavior.AllowGet) : null;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCityByProvId(string id)
        {
            int pId;
            bool valid = Int32.TryParse(id, out pId);
            IList<City> result = null;
            if (valid)
            {
                result = _cityService.GetCitiesByProvinceId(pId);
            }
            return result != null ? Json(result.Select(x=>new {x.CityId,x.CityName}), JsonRequestBehavior.AllowGet) : null;
        }
        [System.Web.Mvc.AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllCountries()
        {
            var lstcountry = _countryService.GetAllCountries().Select(x => new {x.CountryId, x.CountryName});

            return Json(lstcountry, JsonRequestBehavior.AllowGet);
        }

        public Dictionary<string, object> GetErrorsFromModelState(byte state, string message)
        {

            var msg = new Dictionary<string, object>();
            switch (state)
            {
                case 1:
                    {
                        foreach (var key in ModelState.Keys)
                        {
                            // Only send the errors to the client.
                            if (ModelState[key].Errors.Count > 0)
                            {
                                msg[key] = ModelState[key].Errors;
                            }
                        }

                        break;
                    }
                case 2:
                    {
                        msg["error"] = message;
                        break;
                    }
                case 3:
                    {
                        msg["success"] = message;
                        break;
                    }
            }
            return msg;
        }

        // این متد جاش اینجاااااا نیستااا ولی برای عرووسی عجله دارم که قبل عرووووسی تحوویلت بدم پرووژه روو هووووووووووورااااااااا
        public JsonResult InsertComment(Comment comment)
        {
            if (!ModelState.IsValid) return Json(new { valid = ModelState.IsValid, Error = GetErrorsFromModelState(1, "اطلاعات ارسالی درست نمی باشد") });

                int idcommenter = 0;
                var ws = new WorkSession();
                if (ws.IsLoginUser())
                {
                    idcommenter = ws.GetId();
                }
            comment.Cominfo.CommenterIpAddress =
                Request.ServerVariables["REMOTE_ADDR"].ToString(CultureInfo.InvariantCulture);
            comment.ComTime = DateTime.Now;
            comment.Cominfo.CommeterId = idcommenter;

            if (_commentService.InsertComment(comment)) 
                return Json(new { valid = ModelState.IsValid, Error = GetErrorsFromModelState(3, "پیغام شما با موفقیت در سیستم ثبت شد") });
            return Json(new { valid = false, Error = GetErrorsFromModelState(2, "خطایی در هنگام ذخیره اطلاعات رخ داده است لطفا پس از مدتی دوباره تلاش فرمایید") });
               
            }

           
    }
}
