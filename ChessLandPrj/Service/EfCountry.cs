using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
    public class EfCountry:ICountry
    {
        private IUnitOfWork _uow;
        private IDbSet<Country> _countries;
        public EfCountry(IUnitOfWork uow)
        {
            _uow = uow;
            _countries = _uow.Set<Country>();
            
        }
        public IList<Models.Country> GetAllCountries()
        {
            return _countries.ToList();
        }
    }
}