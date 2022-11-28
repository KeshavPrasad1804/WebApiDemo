using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Entities;
using WebApiDemo.Repos;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowsController : ControllerBase
    {
        MyUnitofWork unitofWork = null;
        public MovieShowsController(MyUnitofWork uoW)
        {
            unitofWork = uoW;
        }
        [HttpGet]
        public List< MovieShowsDTO> GetAllMovieShows()
        {
            List<MovieShowsDTO> list = unitofWork.MovieShowsRepo.GetAll();
            return list;
        }
        [HttpPost]
        public string AddMovieShows(MovieShowsDTO inp)
        {
            bool Status = false;
            bool res = unitofWork.MovieShowsRepo.Add(inp);
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
        public IActionResult UpdateMovieShows(MovieShowsDTO inp)
        {
            bool status = false;
            bool res = unitofWork.MovieShowsRepo.Update(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("Shows Updated");
            }
            else
                return NotFound("Shows Not Found");


        }
        [HttpDelete]
        public IActionResult DeleteMovieShows(int inp)
        {
            bool status = false;
            bool res = unitofWork.MovieShowsRepo.Delete(inp);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("Shows Deleted with Show ID : " + inp);
            }
            else
            {
                return NotFound("Shows Not Found");
            }
        }
    }
}
