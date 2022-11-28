using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;
using WebApiDemo.Repos;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplexController : ControllerBase
    {
        MyUnitofWork unitofWork = null;
        public MultiplexController(MyUnitofWork uoW)
        {
            unitofWork = uoW;
        }
        [HttpGet]
        public List<MultiplexDTO> GetAllMultiplexes()
        {
            List<MultiplexDTO> list = unitofWork.MultiplexRepo.GetAll();
            return list;
        }
        [HttpPost]
        public string AddMultiplex(MultiplexDTO inp)
        {
            bool Status = false;
            bool res = unitofWork.MultiplexRepo.Add(inp);
            if (res)
            {
                Status = unitofWork.SaveAll();
            }
            if (Status)
            {
                return "Success";
            }
            else
                return "Failed";
        }
        [HttpPut]
        public IActionResult UpdateMultiplex(MultiplexDTO inp)
        {
            bool status = false;
            bool res = unitofWork.MultiplexRepo.Update(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("Multiplex Updated");
            }
            else
                return NotFound("Multiplex Not Found");


        }
        [HttpDelete]
        public IActionResult DeleteMultiplex(int inp)
        {
            bool status = false;
            bool res = unitofWork.MultiplexRepo.Delete(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("Multiplex Deleted with Multiplex ID : " + inp);
            }
            else
            {
                return NotFound("Multiplex Not Found");
            }
        }

    }
}
