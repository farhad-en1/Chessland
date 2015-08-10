using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLandPrj.Models;
using ChessLandPrj.Models.ViewModel;

namespace ChessLandPrj.Service
{
    public interface IAccount
    {
        bool AddNewAccount(Account acc);
        Account LoginAcocunt(string username, string password);
        bool AccountNameExist(string username, string email);
        Account GetInfoAccount(int accountId);
        bool EditAccount(_Editprofile account,int accountId);

    }
}
