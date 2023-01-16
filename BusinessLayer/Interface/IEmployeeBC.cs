using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;
namespace BusinessLayer.Interface
{
    public interface IEmployeeBC
    {
        Task<IQueryable<TblEmployee>> Obtener();
        Task<IQueryable<TblEmployee>> Obtenerpro(string valorbuscado);
        
        Task<GE::Employee> getEmployebyid(int idEmpleado);
        Task<string> Save(GE::Employee employee);

        Task<string> RemoveEmployee(int idEmpleado);
        
    }
}
