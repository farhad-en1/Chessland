using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using GalleryDataHelper.externalmodel;
using MIDP.Models.ViewModels;

namespace GalleryDataHelper
{
    public class XmlReader
    {
        public List<Gallery> GalleryList()
        {
            
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Gallery.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var Gallerys = new List<Gallery>();
            Gallerys = (from rows in ds.Tables[0].AsEnumerable()
                        select new Gallery()
                        {
                            id = Convert.ToInt32(rows[0].ToString()), //Convert row to int  
                            name = rows[1].ToString(),
                            title = rows[2].ToString(),
                        }).ToList();
            return Gallerys;

        }

        public AboutUs AboutInfo()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/aboutus.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var about = new AboutUs();
            about=(from rows in ds.Tables[0].AsEnumerable()
                select new AboutUs()
                {
                    Id = Convert.ToInt32(rows[0].ToString()), //Convert row to int  
                    Title = rows[1].ToString(),
                    Body = rows[2].ToString(),
                    ImgName = rows[3].ToString(), 
                }).LastOrDefault();
            return about;

        }
    }
}
