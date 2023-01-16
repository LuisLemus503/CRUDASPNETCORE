using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using GlobalEntity;
using GE = GlobalEntity;
namespace BusinessLayer
{
    public class EmployeeBC:IEmployeeBC
    {
        private readonly IEmployeeDA employeeDA;

        public EmployeeBC(IEmployeeDA employeeDA)
        {

            this.employeeDA = employeeDA;


        }

        public async Task<IQueryable<TblEmployee>> Obtenerpro(string valorbuscado) {


            return await this.employeeDA.Obtenerpro(valorbuscado);
        }

        public async Task<IQueryable<TblEmployee>> Obtener()
        {

            return await this.employeeDA.Obtener();
        
        }
        
        public async Task<GE::Employee> getEmployebyid(int idEmpleado)
        {

            return await this.employeeDA.getEmployebyid(idEmpleado);

        }

        public async Task<string> Save(GE::Employee employee) {

            return await this.employeeDA.Save(employee);
        
        }

        public async Task<string> RemoveEmployee(int idEmpleado) {

            return await this.employeeDA.RemoveEmployee(idEmpleado);

        }

        


    }
}