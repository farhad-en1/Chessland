using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
     public interface IProvince
    {
        IList<Province> GetProvinceByCountryId(int idCountry);
    }
}
