using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dummy2.Repository.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();  
        TEntity GetByID(int id);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        dynamic Add(TEntity entity);
        dynamic Update(TEntity entityToUpdate);
        dynamic Delete(TEntity entityToDelete);
        dynamic Delete(int  id);
        dynamic Count();
    }
}
