using System;
using System.Web;

namespace ChessLandPrj.BenfitClass
{
    public class WorkSession
    {
        private int _idUser;
        private const string SessionUserData = "user";

        public bool IsLoginUser()
        {
            if (HttpContext.Current.Session[SessionUserData] != null)
            {
                if (Int32.TryParse(HttpContext.Current.Session[SessionUserData].ToString(), out _idUser))
                {
                    return true;
                }
 
            }
            return false;
        }

        public int GetId()
        {
            return _idUser;
        }

        public string Addsession(string key,string value)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
            HttpContext.Current.Session[key] = value;
            return value;
        }

    }
}