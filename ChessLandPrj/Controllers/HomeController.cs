using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ChessLandPrj.BenfitClass;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;
using ChessLandPrj.Models.ViewModel;
using GalleryDataHelper;


namespace ChessLandPrj.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult ViewAllGallery()
        {
            var reader =  new GalleryDataHelper.XmlReader();
            var data = reader.GalleryList();
            return View(data.ToList());   
        }

        public ActionResult DownloadIndex()
        {
            return View();
        }
        public FileResult DownloadFile()
        {
            var filename = Url.Content("~/ChessGameFile/test.zip");
            const string content = "application/zip";
            //  var x = "~/ChessGameFile/nesa.zip, System.Net.Mime.MediaTypeNames.Application.Octet,chess)";
            return File(filename, content, "chess.zip");
        }

        public ActionResult Aboutus()
        {
            var reader = new GalleryDataHelper.XmlReader();
            var data = reader.AboutInfo();
            ViewData["title"] = data.Title;
            ViewData["body"] = data.Body;
            ViewData["img"] = data.ImgName;

            return View("_aboutus");
        }

        public ActionResult Preamble()
        {
            string filepath = Server.MapPath("~/App_Data/preamble.txt");
            string content = string.Empty;

            try
            {
                using (var stream = new StreamReader(filepath))
                {
                    content = stream.ReadToEnd();
                }
            }
            catch (Exception exc)
            {
                return Content("خطااااااااااایه!");
            }
            ViewBag.content = content;

            return View("_ShowPreamble");
        }

    }
}
