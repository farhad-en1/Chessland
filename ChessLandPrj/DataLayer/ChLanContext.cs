using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Xml;
using ChessLandPrj.Mapping;
using ChessLandPrj.Models;

namespace ChessLandPrj.DataLayer
{
    public class ChLanContext:DbContext,IUnitOfWork
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<City>  Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<TicketQstion> TicketQstions { get; set; }
        public DbSet<TicketAnswer> TicketAnswers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountConfig());
            modelBuilder.Configurations.Add(new TicketQstionConfig());
            modelBuilder.Configurations.Add(new CityConfig());
            modelBuilder.Configurations.Add(new CountryConfig());
            modelBuilder.Configurations.Add(new ProvinceConfig());
            
            

            base.OnModelCreating(modelBuilder);
        }

        public int SaveAllChanges()
        {
            return base.SaveChanges();
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters).ToList();
        }


        void ExportMappings(DbContext context, string edmxFile)
        {
            var settings = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(edmxFile, settings))
            {
                System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(context, writer);
            }
        }
    }
   


}