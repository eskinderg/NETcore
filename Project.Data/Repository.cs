using System.Collections.Generic;
using System.Linq;
using Project.Model;
using System;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public Repository(IDbContext context)
        {
            _context = context;
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            //try
            //{
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);

                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbException)
            //{
            //    throw new Exception(GetFullErrorText(dbException), dbException);
            //}
        }

        public void Insert(IEnumerable<T> entities)
        {
            //try
            //{
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Add(entity);

                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbException)
            //{
            //    throw new Exception(GetFullErrorText(dbException), dbException);
            //}
        }


        public void Update(T entity)
        {
            //try
            //{
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbException)
            //{
            //    throw new Exception(GetFullErrorText(dbException), dbException);
            //}
        }

        public void Update(IEnumerable<T> entities)
        {
            //try
            //{
                if (entities == null)
                    throw new ArgumentNullException("entities");

                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbException)
            //{
            //    throw new Exception(GetFullErrorText(dbException), dbException);
            //}
        }


        public void Delete(T entity)
        {
            //try
            //{
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);

                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbException)
            //{
            //    throw new Exception(GetFullErrorText(dbException), dbException);
            //}
        }

        public void Delete(IEnumerable<T> entities)
        {
            //try
            //{
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Remove(entity);

                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbException)
            //{
            //    throw new Exception(GetFullErrorText(dbException), dbException);
            //}
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        private DbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

        //private string GetFullErrorText(DbEntityValidationException exc)
        //{
        //    var msg = string.Empty;
        //    foreach (var validationErrors in exc.EntityValidationErrors)
        //        foreach (var error in validationErrors.ValidationErrors)
        //            msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
        //    return msg;
        //}

        
    }

}