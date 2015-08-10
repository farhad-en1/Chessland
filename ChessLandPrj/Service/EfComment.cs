using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChessLandPrj.DataLayer;
using ChessLandPrj.Models;

namespace ChessLandPrj.Service
{
    public class EfComment:IComment
    {
        private IUnitOfWork _uow;
        private IDbSet<Comment> _comments;

        public EfComment(IUnitOfWork uow)
        {
            _uow = uow;
            _comments = _uow.Set<Comment>();
        }
        public bool InsertComment(Comment comment)
        {
            _comments.Add(comment);
            try
            {
                _uow.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
            
        }
    }
}