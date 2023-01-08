using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;
namespace DataAccessLayer.Interface
{
    public interface IEmployeeDA
    {
        Task< List<GE::Employee>> getEmploye();

         Task<GE::Employee> getEmployebyid(int IdEmpleado);

        Task<string> Save(GE::Employee employee);

         Task<string> RemoveEmployee(int IdEmpleado);


    }
}
