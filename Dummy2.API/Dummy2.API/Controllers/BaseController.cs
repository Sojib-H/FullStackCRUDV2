using Dummy2.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Dummy2.API.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Uow { get; set; }
    }
}
