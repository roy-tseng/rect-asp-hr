namespace rect_asp_hr.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using infolink.rect_asp_hr.Models;
    
    [ApiController]
    [Route("[controller]")]
    public class EmployeeMgmtController : ControllerBase
    {
        private MySQLContext context = null;

        public EmployeeMgmtController(MySQLContext dbContext){

            this.context = dbContext;

        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "hello";
        }        

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Post([FromBody] Employee member){
            Console.WriteLine(member.name);
            return member.name;
        }
    }
}