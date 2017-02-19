using CodeMash.Net;
using Employees.BusinessContract;
using Employees.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Employees.BusinessImplementation
{
    public class EmployeeService : IEmployeeService
    {
        IGrossCalculation grossCalculation = new GrossCalculation();

        public void CreateEmployee(Employee employee)
        {
            Db.InsertOne(employee);
        }

        public bool DeleteEmployee(string id)
        {
            var result = Db.DeleteOne<Employee>(x => x.Id == ObjectId.Parse(id));

            return result.DeletedCount == 1;
        }

        public List<ViewModel> GetAllEmployees(string name = "")
        {
            List<ViewModel> viewModelEmployees = new List<ViewModel>();

            var filterBuilder = Builders<Employee>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                var findByNameFilter = Builders<Employee>.Filter.Eq(x => x.Name, name);
                filter = filter & findByNameFilter;
            }

            var employees = Db.Find(filter);

            // Map
            foreach (var employee in employees)
            {
                viewModelEmployees.Add(new ViewModel()
                {
                    Name = employee.Name,
                    LastName = employee.LastName,
                    SalaryOnHands = employee.SalaryOnHands,
                    SalaryOnPaper = grossCalculation.Count(employee.SalaryOnHands),
                    Id = employee.Id.ToString()           
                });
            }

            return viewModelEmployees;
        }

        public Employee GetEmployee(string id)
        {
            return Db.FindOneById<Employee>(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            Db.FindOneAndReplace(x => x.Id == employee.Id, employee);
        }
    }
}