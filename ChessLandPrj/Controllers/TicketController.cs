using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessLandPrj.BenfitClass;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;
using ChessLandPrj.Service;

namespace ChessLandPrj.Controllers
{
    public class TicketController : Controller
    {
        readonly IAccount _accountService;
        readonly ITicket _ticketService;
        readonly IUnitOfWork _uow;

        public TicketController(IUnitOfWork uow, IAccount accountService, ITicket ticketService)
        {
            _accountService = accountService;
            _ticketService = ticketService;
            _uow = uow;

        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SendQstion()
        {
            var seuser = new WorkSession();
            if (seuser.IsLoginUser())
            {
                return View("_SendQstion");
            }
            ViewBag.message = "برای ارسال تیک شما نیاز دارید وارد سیستم کاربری خود شوید";
            return View("_NotLogin");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveQstion(TicketQstion qstion)
        {
            qstion.RegTime = DateTime.Now;
            if (Session["user"] == null) return Json(new { valid = false, message = "لطفا ابتدا وارد سیستم شوید" });
            int iduser;
            if (!Int32.TryParse(Session["user"].ToString(), out iduser)) return Json(new { valid = false, message = "خطایی  در سیستم پیش امده است" });
            var acc = _accountService.GetInfoAccount(iduser);
            if (acc == null) return Json(new { valid = false, message = "خطایی  در سیستم پیش امده است" });
            qstion.Acc = acc;
            if (_ticketService.AddQStion(qstion)) return Json(new { valid = true, message = "تیکت با موفقیت ارسال گردید" });
            return Json(new { valid = false, message = "خطایی در هنگام ارسال تیک به وجود آمده است" });


        }

        public ActionResult ViewQstionWithAnswer()
        {
            ViewBag.message = "لطفا برای مشاهده تیک ارسالی و پاسخ آن ها وارد حساب کاربری خود شوید";
            var seUser = new WorkSession();
            if (seUser.IsLoginUser())
            {
                var iduser = seUser.GetId();
                var getAllquestion = _ticketService.ViewAllQstionUser(iduser);
                return View("_ViewQstion", getAllquestion);
            }
            return View("_NotLogin");
        }

    }
}
