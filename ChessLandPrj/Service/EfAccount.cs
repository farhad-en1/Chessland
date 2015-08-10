using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessLandPrj.BenfitClass;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;
using ChessLandPrj.Models.ViewModel;

namespace ChessLandPrj.Service
{
    public class EfAccount:IAccount
    {
        private IUnitOfWork _uow;
        private IDbSet<Account> _accounts;

        public EfAccount(IUnitOfWork uow)
        {
            _uow = uow;
            _accounts = _uow.Set<Account>();
        }

        public bool AddNewAccount(Models.Account acc)
        {
            try
            {
                _accounts.Add(acc);
                
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public Models.Account LoginAcocunt(string username, string password)
        {
            var x = (from o in _accounts
                where o.UserName == username && o.Password == password
                select o).FirstOrDefault();

            return x;
        }

        public bool AccountNameExist(string username,string email)
        {
            return _accounts.Any(x => x.UserName == username || x.Email == email);
        }

        public Account GetInfoAccount(int accountId)
        {
            return _accounts.Find(accountId);
        }

        public bool EditAccount(_Editprofile account,int accontId)
        {
            
           var acc=_accounts.Find(accontId);
            if (acc != null)
            {
                acc.FirstName = account.FirstName ?? acc.FirstName;
                acc.LastName = account.LastName ?? acc.LastName;
                acc.Gender = account.Gender ?? acc.Gender;
                acc.Email = account.Email ?? acc.Email;
                acc.ConfirmPassword = acc.Password;
            
            
            try
            {
                _uow.SaveChanges();
                var ws = new WorkSession();
                ws.Addsession("welcome", ((acc.Gender == 1) ? "آقای " : "خانم ") + acc.FirstName + " " + acc.LastName);
                return true;
            }
            catch
            {
                return false;
            }
            }
            return false;
        }
    }
}