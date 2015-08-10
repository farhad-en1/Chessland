﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
    public interface ICity
    {
        IList<City> GetCitiesByProvinceId(int idProvince);
        City GetCityById(int idcity);
    }
}
