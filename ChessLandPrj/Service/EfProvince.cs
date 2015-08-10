using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
    public class EfProvince:IProvince
    {
        private IUnitOfWork _uow;
        private IDbSet<Province> _provinces;

        public EfProvince(IUnitOfWork uow)
        {
            _uow = uow;
            _provinces = _uow.Set<Province>();
        }


        public IList<Province> GetProvinceByCountryId(int idCountry)
        {
          return  _provinces.Where(x => x.Country.CountryId == idCountry).ToList();

        }
    }
}