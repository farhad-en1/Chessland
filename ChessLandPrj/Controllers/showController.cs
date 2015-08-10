using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChessLandPrj.Service;

namespace ChessLandPrj.Controllers
{
    public class showController : ApiController
    {
       private ICity idetail = null;
       public showController(ICity Idetail)
       {
           idetail = Idetail;
       }
       [HttpGet]
       public string GetValue()
       {
           return "jhghjhj";             
       }   
    }
}
