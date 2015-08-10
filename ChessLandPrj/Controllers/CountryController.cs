using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;
using ChessLandPrj.Service;


namespace ChessLandPrj.Controllers
{
    public class CountryController : ApiController
    {
        private ICountry _countryService;
        private IUnitOfWork _uow;
        public CountryController(IUnitOfWork uow, ICountry countryService)
        {
            _countryService = countryService;
            _uow = uow;
        }
        [System.Web.Mvc.AcceptVerbs(HttpVerbs.Get)]
        public IEnumerable<Country> GetAllCountries()
        {

            return _countryService.GetAllCountries();
        }
    }
}
