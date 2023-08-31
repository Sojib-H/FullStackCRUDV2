using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dummy2.Repository.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            this.dbSet= _context.Set<TEntity>();
        }

        public dynamic Add(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                return Save(1);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return null;
        }

        public dynamic Count()
        {
            try
            {
                return dbSet.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public dynamic Delete(TEntity entityToDelete)
        {
            try
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
                return Save(3);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public dynamic Delete(int id)
        {
            try
            {
                TEntity entity = dbSet.Find(id);
                dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                return Save(3);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return dbSet.Where(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return dbSet.FirstOrDefault(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity GetByID(int id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public dynamic Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                return Save(2);

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return null;
        }

        public dynamic Save(int option)
        {
            try
            {
                var res = _context.SaveChanges();
                if (res == 1 && option == 1)
                {
                    return "Data Saved Successfully";
                }
                if (res == 1 && option == 2)
                {
                    return "Data Updated Successfully";
                }
                if (res == 1 && option == 3)
                {
                    return "Data Deleted Successfully";
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
