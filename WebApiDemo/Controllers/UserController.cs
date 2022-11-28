using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Entities;
using WebApiDemo.Repos;

namespace WebApiDemo.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MyUnitofWork unitofWork = null;
        public UserController(MyUnitofWork uoW)
        {
            unitofWork = uoW;
        }
        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            bool status = false;
            bool res = unitofWork.UserRepo.Login(login);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("User Logged in Successfully");
            }
            else
                return NotFound("Invalid Credentials");

        } 
        [HttpPost]
        public IActionResult Register(User user)
        {
            bool status = false;
            bool res = unitofWork.UserRepo.Register(user);
            if (res)
            {
                status = unitofWork.SaveAll();
            }
            if (status)
            {
                return Ok("User Logged in Successfully");
            }
            else
                return NotFound("Invalid Credentials");

        } 
    }
}
