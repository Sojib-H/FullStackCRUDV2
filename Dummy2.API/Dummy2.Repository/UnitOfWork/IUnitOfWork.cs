using Dummy2.Model;
using Dummy2.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy2.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> TblUserRepository { get; }
    }
}
