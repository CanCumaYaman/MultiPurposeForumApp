using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getfullnamebymail")]

        public IActionResult GetByFullNameByEmail(string mail)
        {
            var result = _userService.GetFullNameByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpGet("getfullnamebyid")]

        public IActionResult GetByFullNameById(int id)
        {
            var result = _userService.GetFullNameById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }



        [HttpGet("getuserid")]

        public IActionResult GetUserIdByMail(string mail)
        {
            var result = _userService.Find(p => p.Email == mail);
            if (result.Success)
            {
                return Ok(result.Data.Id);
            }
            return BadRequest(result);

        }

    }
}
