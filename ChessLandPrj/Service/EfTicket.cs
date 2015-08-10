using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;
using ChessLandPrj.Models.ViewModel;

namespace ChessLandPrj.Service
{
    public class EfTicket:ITicket
    {
        private IUnitOfWork _uow;
        private IDbSet<TicketQstion> _ticketQstions;


        public EfTicket(IUnitOfWork uow)
        {
            _uow = uow;
            _ticketQstions = _uow.Set<TicketQstion>();
        }

        public bool AddQStion(TicketQstion qstion)
        {
            _ticketQstions.Add(qstion);
            try
            {
                _uow.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public IQueryable<TicketQstion> ViewAllQstionUser(int idUser)
        {
            return _ticketQstions.Where(x => x.Acc.AccountId == idUser).Include("TicketAnswer");
        }


    }
}