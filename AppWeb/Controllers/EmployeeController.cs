using BusinessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using GE = GlobalEntity;
namespace AppWeb.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeBC employeeBC;
        public EmployeeController(IEmployeeBC employeeBC)
        {

            this.employeeBC = employeeBC;

        }
        public IActionResult Index()
        {
            //List<GE::Employee> employees = await this.employeeBC.getEmployees();
            return View();
        }
        /*
        private readonly LearnDbContext learnDbContext;
        public EmployeeController(LearnDbContext learnDbContext)
        {
            this.learnDbContext = learnDbContext;
        }*/
        
        public IActionResult Create ()
        {
            
            return View(new GE.Employee());
        }

        public async Task<IActionResult> Edit(int idEmpleado)
        {
            GE::Employee employees = await this.employeeBC.getEmployebyid(Convert.ToInt32(idEmpleado));
            return View("Create", employees);
        }


        public async Task<IActionResult> Save(GE::Employee employee) {

            string Response = await this.employeeBC.Save(employee);
            return Json(Response);
        
        }

        public async Task<IActionResult> Remove(string idEmpleado)
        {

            string Response = await this.employeeBC.RemoveEmployee(Convert.ToInt32( idEmpleado));
            return Json(Response);

        }


        public async Task<IActionResult> GetAll(string valorbuscado)
        {

            int Nrorepeticion = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");
            int Cantidadderegistros = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int Omitirregistros = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            valorbuscado = Request.Form["search[value]"].FirstOrDefault() ?? "";
            List<TblEmployee> lista = new List<TblEmployee>();

            IQueryable<TblEmployee> query = await this.employeeBC.Obtener();
            int totalregistros = query.Count();

           // IQueryable<TblEmployee> quuery = await this.employeeBC.Obtenerpro(valorbuscado);

            int totalregistrosfiltrados = query.Count();



                lista = query.Skip(Omitirregistros).Take(Cantidadderegistros).ToList();
            


            return Json(new
            {
                draw = Nrorepeticion,
                recordsTotal = totalregistros,
                recordsFiltered = totalregistrosfiltrados,
                data = lista
            });

        }
    }
}
