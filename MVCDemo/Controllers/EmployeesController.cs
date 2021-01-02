using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<MvcEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result; 
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new MvcEmployeeModel());
        }

        [HttpPost]
     public ActionResult AddOrEdit(MvcEmployeeModel mvcEmployeeModel)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employees", mvcEmployeeModel).Result;
            return RedirectToAction("Index");
        }
    }
}