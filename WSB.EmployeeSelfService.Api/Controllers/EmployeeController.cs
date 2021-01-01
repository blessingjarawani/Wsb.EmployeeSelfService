using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace WSB.EmployeeSelfService.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
