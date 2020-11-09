namespace rect_asp_hr.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    
    [ApiController]
    [Route("[controller]")]
    public class EmployeeMgmtController : ControllerBase
    {
        public EmployeeMgmtController(){

        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "hello";
        }        

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Post([FromBody] Member member){
            Console.WriteLine(member.name);
            return member.name;
        }
    }

    public class Member 
    {
        public string name {get; set;}= string.Empty;

    }
}