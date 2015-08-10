using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
    public interface ICountry
    {
        IList<Country> GetAllCountries();
    }
}
