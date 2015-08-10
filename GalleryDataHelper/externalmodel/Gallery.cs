using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GalleryDataHelper.externalmodel
{
    [Serializable]
    [XmlRoot("gallery"), XmlType("gallery")]  
   public class Gallery
    {
        public int id { set; get; }
        public string name { set; get; }
        public string title { set; get; }

    }
}
