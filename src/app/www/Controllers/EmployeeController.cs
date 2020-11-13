
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rect_asp_hr.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using infolink.rect_asp_hr.Models;

    public class EmployeeController : Controller
    {
        private MySQLContext contextDataBase =  null;

        public EmployeeController(MySQLContext dataContext){
            this.contextDataBase = dataContext; 
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
