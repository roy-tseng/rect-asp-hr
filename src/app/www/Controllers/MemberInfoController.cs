namespace rect_asp_hr.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using INFOLINK.ShareLibs;
    using infolink.rect_asp_hr.Models;

    [ApiController]
    [Route("[Controller]")]
    public class MemberInfoController : ControllerBase
    {
        private readonly JWTHelper jwtHelper;

        public MemberInfoController(JWTHelper jwtHelper)
        {
            this.jwtHelper = jwtHelper;
        }

        // ~ means root path: https://xxx:sigin
        [AllowAnonymous]
        [HttpPost("~/signin")]
        public ActionResult<string> SignIn(LoginInfo login)
        {
            if (ValidateUser(login))
            {
                return this.jwtHelper.GenerateToken(login.Name);
            }
            else
            {
                return BadRequest();
            }
        }
        
        [Authorize]
        [HttpGet("~/username")]
        public IActionResult GetUserName(string id)
        {
            return Ok("Member");
        }

        private bool ValidateUser(LoginInfo loginInfo)
        {
            return true;            
        }
    }
}