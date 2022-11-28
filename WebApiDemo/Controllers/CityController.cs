using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Entities;
using WebApiDemo.Repos;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        MyUnitofWork unitofWork = null;
        public CityController(MyUnitofWork uoW)
        {
            unitofWork = uoW;
        }
        [HttpGet]
        public List<CityDTO> GetAllCities()
        {
            List<CityDTO> list=unitofWork.CityRepo.GetAll();
            return list;
        }
        [HttpPost]
        public string AddCity(CityDTO inp)
        {
            bool Status=false;
            bool res = unitofWork.CityRepo.Add(inp);
            if (res)
            {
                Status=unitofWork.SaveAll();
            }
            if (Status)
            {
                return "Success";
            }
            else
                return "Failed";
          
        }
        [HttpPut]
        public IActionResult UpdateCity(CityDTO inp)
        {
           bool status=false;
            bool res = unitofWork.CityRepo.Update(inp);
            if (res)
            {
                status=unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("City Updated");
            }
            else
                return NotFound("City Not Found");


        }
        [HttpDelete]
        public IActionResult DeleteCity(int inp)
        {
            bool status = false;
            bool res = unitofWork.CityRepo.Delete(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status) {
                return Ok("City Deleted with City ID : " + inp);
            }
            else
            {
                return NotFound("City Not Found");
            }
        }
    }
}
