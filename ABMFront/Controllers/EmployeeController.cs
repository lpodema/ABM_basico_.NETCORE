using System.Net;
using ABMFront.Services;
using Microsoft.AspNetCore.Mvc;
using ABMFront.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ABMFront.Controllers
{
    public class EmployeeController : Controller
    {
        // [ViewData]
        // public string Title { get; set; } = "Employee CRUD";
        [BindProperty]
        public EmployeeViewModel employeeViewModel { get; set; }

        public IActionResult Index()
        {

            return View("Views/Employee/Index.cshtml");
        }

        [HttpGet]
        public JsonResult ShowAllEmployees()
        {
            EmployeeService employeeService = new EmployeeService();
            return new JsonResult(employeeService.GetAllEmployees());
        }

        [HttpPost]
        public void CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            EmployeeService employeeService = new EmployeeService();
            employeeService.CreateEmployee(employeeViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ViewDetails([FromQuery]int id)
        {

            EmployeeService employeeService = new EmployeeService();
            this.employeeViewModel = employeeService.ShowEmployeeById(id);

            return View("Views/Employee/ViewDetails.cshtml", employeeViewModel);
        }


        [HttpPost]
        public void EditEmployee(EmployeeViewModel employeeViewModel)
        {
            EmployeeService employeeService = new EmployeeService();
            employeeService.ModifyEmployee(employeeViewModel);
            //return RedirectToAction("Index");
        }

        public void DeleteEmployee(EmployeeViewModel employeeViewModel)
        {
            EmployeeService employeeService = new EmployeeService();
            employeeService.DeleteEmployee(employeeViewModel);
            //return RedirectToAction("Index");
        }

    }
}