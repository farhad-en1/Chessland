using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
    public class EfCity:ICity
    {
        private IUnitOfWork _uow;
        private IDbSet<City> _cities;

        public EfCity(IUnitOfWork uow)
        {
            _uow = uow;
            _cities = _uow.Set<City>();
        }

        public IList<Models.City> GetCitiesByProvinceId(int idProvince)
        {
            return _cities.Where(x => x.Prov.ProvinceId == idProvince).ToList();
        }

        public City GetCityById(int idcity)
        {
            return _cities.SingleOrDefault(x => x.CityId == idcity);
        }
    }
}