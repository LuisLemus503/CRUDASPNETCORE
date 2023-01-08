using BusinessLayer.Interface;
using DataAccessLayer.Interface;
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

        public async Task<List<GE::Employee>> getEmployees() {

            return await this.employeeDA.getEmploye();
        
        }

        public async Task<GE::Employee> getEmployebyid(int IdEmpleado)
        {

            return await this.employeeDA.getEmployebyid(IdEmpleado);

        }

        public async Task<string> Save(GE::Employee employee) {

            return await this.employeeDA.Save(employee);
        
        }

        public async Task<string> RemoveEmployee(int IdEmpleado) {

            return await this.employeeDA.RemoveEmployee(IdEmpleado);

        }




    }
}