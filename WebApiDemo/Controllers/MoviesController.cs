using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Entities;
using WebApiDemo.Repos;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        MyUnitofWork unitofWork = null;
        public MoviesController(MyUnitofWork uoW)
        {
            unitofWork = uoW;
        }
        [HttpGet]
        public List<MoviesDTO> GetAllMovies()
        {
            List<MoviesDTO> list = unitofWork.MovieRepo.GetAll();
            return list;
        }
        [HttpPost]
        public string AddMovies(MoviesDTO inp)
        {
            bool Status = false;
            bool res = unitofWork.MovieRepo.Add(inp);
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
        public IActionResult UpdateMovies(MoviesDTO inp)
        {
            bool status = false;
            bool res = unitofWork.MovieRepo.Update(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("Movies Updated");
            }
            else
                return NotFound("Movies Not Found");

        }
        [HttpDelete]
        public IActionResult DeleteMovie(int inp)
        {
            bool status = false;
            bool res = unitofWork.MovieRepo.Delete(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("Movies Deleted with Movie ID : " + inp);
            }
            else
            {
                return NotFound("Movie Not Found");
            }
        }
    }
}
