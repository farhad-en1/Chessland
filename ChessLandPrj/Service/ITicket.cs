using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLandPrj.Models;
using ChessLandPrj.Models.ViewModel;

namespace ChessLandPrj.Service
{
    public interface ITicket
    {
        bool AddQStion(TicketQstion qstion);
        IQueryable<TicketQstion> ViewAllQstionUser(int idUser);
    }
}
