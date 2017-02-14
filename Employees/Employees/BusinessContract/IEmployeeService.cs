using Employees.Models;
using System.Collections.Generic;

namespace Employees.BusinessContract
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        bool DeleteEmployee(string id);
        List<ViewModel> GetAllEmployees(string name = "");
        Employee GetEmployee(string id);
    }
}