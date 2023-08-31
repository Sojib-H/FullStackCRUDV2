using Dummy2.Model;
using Dummy2.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy2.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        private IRepository<User> tblUserRepository;
        public IRepository<User> TblUserRepository
        { 
            get 
            { 
                if (this.tblUserRepository == null)
                {
                    this.tblUserRepository = new Repository<User>(_context);
                }
                return tblUserRepository; 
            } 
        }
    }
}
