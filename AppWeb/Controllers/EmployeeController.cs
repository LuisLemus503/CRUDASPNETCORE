using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using GE = GlobalEntity;
namespace AppWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBC employeeBC;
        public EmployeeController(IEmployeeBC employeeBC) {

            this.employeeBC = employeeBC;
        
        }
        public async Task< IActionResult> Index()
        {
            List<GE::Employee> employees = await this.employeeBC.getEmployees();
            return View(employees);
        }

        public IActionResult Create ()
        {
            
            return View(new GE.Employee() );
        }

        public async Task<IActionResult> Edit(string IdEmpleado)
        {
            GE::Employee employees = await this.employeeBC.getEmployebyid(Convert.ToInt32(IdEmpleado));
            return View("Create", employees);
        }


        public async Task<IActionResult> Save(GE::Employee employee) {

            string Response = await this.employeeBC.Save(employee);
            return Json(Response);
        
        }

        public async Task<IActionResult> Remove(string IdEmpleado)
        {

            string Response = await this.employeeBC.RemoveEmployee(Convert.ToInt32(  IdEmpleado));
            return Json(Response);

        }
    }
}
