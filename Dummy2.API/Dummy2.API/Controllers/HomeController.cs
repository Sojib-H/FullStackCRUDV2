using Dummy2.Model;
using Dummy2.Model.Common;
using Dummy2.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Dummy2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        [HttpPost("[action]")]
        public IEnumerable<User> GetAllUserByID([FromBody] int UserID)
        {
            try
            {
                return Uow.TblUserRepository.FindBy(m => m.UserID == UserID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("[action]")]
        public dynamic GetAllUsers()
        {
            try
            {
                return Uow.TblUserRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("[action]")]
        public ResponseParam Add([FromBody] User entity)
        {
            try
            {
                Uow.TblUserRepository.Add(entity);

                return new ResponseParam()
                {
                    ResponseCode = "OK",
                    ResponseMsg = entity.Name + " Entry Successfully",
                    ResponseData = "1"
                };
            }
            catch (Exception ex)
            {
                return new ResponseParam()
                {
                    ResponseCode = "OK",
                    ResponseMsg = ex.Message
                };
            }
        }

        [HttpPost("[action]")]
        public ResponseParam Update([FromBody] User entity)
        {
            try
            {
                Uow.TblUserRepository.Update(entity);

                return new ResponseParam()
                {
                    ResponseCode = "OK",
                    ResponseMsg = entity.Name + " Update Successfully",
                    ResponseData = "1"
                };
            }
            catch (Exception ex)
            {
                return new ResponseParam()
                {
                    ResponseCode = "OK",
                    ResponseMsg = ex.Message
                };
            }
        }

        [HttpPost("[action]")]
        public ResponseParam Delete([FromBody] int id)
        {
            try
            {
                var search = Uow.TblUserRepository.FindBy(m => m.UserID == id);
                if (search.Count() > 0)
                {
                    Uow.TblUserRepository.Delete(id);
                    return new ResponseParam()
                    {
                        ResponseCode = "OK",
                        ResponseMsg = "Data Deleted Successfully",
                        ResponseData = "1"
                    };
                }
                else
                {
                    return new ResponseParam()
                    {
                        ResponseCode = "Error",
                        ResponseMsg = "Data Not Deleted",
                        ResponseData = "1"
                    };
                }
            }
            catch (Exception ex)
            {

                return new ResponseParam()
                {
                    ResponseCode = "OK",
                    ResponseMsg = ex.Message
                };
            }
        }



    }
}
