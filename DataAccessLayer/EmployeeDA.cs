using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using GlobalEntity;
using Microsoft.EntityFrameworkCore;
using GE = GlobalEntity;
namespace DataAccessLayer
{
    public class EmployeeDA:IEmployeeDA
    { 
        
        private readonly LearnDbContext learnDbContext;

        public EmployeeDA(LearnDbContext learnDbContext) {

            this.learnDbContext = learnDbContext;
        
        }



        public async Task<IQueryable<TblEmployee>> Obtenerpro(string valorbuscado)
        {
            IQueryable<TblEmployee> quuery = await this.Obtener();

            quuery = (IQueryable<TblEmployee>)quuery.Where(e => string.Concat(e.Nombre).Contains(valorbuscado)).ToListAsync();

            return quuery;

        }

        public async Task<IQueryable<TblEmployee>> Obtener()
        {

            IQueryable<TblEmployee> queery = this.learnDbContext.TblEmployees;

            return queery;

        }

        

        public async Task<GE::Employee> getEmployebyid(int idEmpleado )
        {

            var _data = await this.learnDbContext.TblEmployees.FirstOrDefaultAsync(item =>item.IdEmpleado==idEmpleado);

            GE::Employee employees = new GE.Employee();

            if (_data != null)
            {
                    employees=(new GE.Employee()
                    {

                        IdEmpleado = _data.IdEmpleado,
                        Nombre = _data.Nombre,
                        Edad = _data.Edad,
                        Salario = _data.Salario,
                        FechadeIngreso = _data.FechadeIngreso

                    });

            }

            return employees;

        }


        public async Task<string> Save(GE::Employee employee)
        {

            string Response=string.Empty;


            try
            {
                if (employee.IdEmpleado > 0)
                {

                    var _exist = await this.learnDbContext.TblEmployees.FirstOrDefaultAsync(item => item.IdEmpleado == employee.IdEmpleado);

                    if (_exist != null)
                    {

                        _exist.Nombre = employee.Nombre;
                        _exist.Edad = employee.Edad;
                        _exist.Salario = employee.Salario;
                        _exist.FechadeIngreso = employee.FechadeIngreso;
                    }

                }
                else {

                    TblEmployee _employee = new TblEmployee()
                    {
                        Nombre=employee.Nombre,
                        Edad=employee.Edad,
                        Salario=employee.Salario,
                        FechadeIngreso=employee.FechadeIngreso


                    };
                  await  this.learnDbContext.TblEmployees.AddAsync(_employee);

                }
                await this.learnDbContext.SaveChangesAsync();

                Response = "pass";

            }
            catch (Exception ex) {

                Response = ex.Message;
            
            }

            return Response;

        }



        public async Task<string > RemoveEmployee(int idEmpleado)
        {

            var _data = await this.learnDbContext.TblEmployees.FirstOrDefaultAsync(item => item.IdEmpleado == idEmpleado);

            string Response = string.Empty;

            if (_data != null)
            {
                try
                {
                    this.learnDbContext.TblEmployees.Remove(_data);
                    await this.learnDbContext.SaveChangesAsync();
                    Response = "pass";
                }
                catch (Exception ex) {

                    Response = ex.Message;
                }

            }

            return Response;

        }

    }
}