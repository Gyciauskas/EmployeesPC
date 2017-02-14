using Employees.BusinessContract;
using Employees.BusinessImplementation;
using Employees.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Employees.Controllers
{
    public class EmployeesController : Controller
    {
        // Unity Dependency injection
        IEmployeeService _employeeService = new EmployeeService();

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult List(string employeeName, string employeeLastName, int? page)
        {
            IEnumerable<ViewModel> employees = _employeeService.GetAllEmployees(employeeName);

            // Filter by last name 
            if (!String.IsNullOrEmpty(employeeLastName))
            {
                employees = employees.Where(s => s.LastName.Contains(employeeLastName));
            }

            if (employeeName != null || employeeLastName != null)
            {
                page = 1;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee viewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(viewModel);

                return Redirect("/employees");
            }

            return View(viewModel);
        }

        public ActionResult Update(string id)
        {
            var employee = _employeeService.GetEmployee(id);

            // Work around'as...
            var viewModel = new ViewModel
            {
                Name = employee.Name,
                LastName = employee.LastName,
                SalaryOnHands = employee.SalaryOnHands,
                Id = id
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetEmployee(viewModel.Id.ToString());

                employee.SalaryOnHands = viewModel.SalaryOnHands;

                _employeeService.UpdateEmployee(employee);

                return Redirect("/employees");
            }

            return View(viewModel);
        }

        public ActionResult Delete(string id)
        {
            var response = _employeeService.DeleteEmployee(id);

            return Redirect("/employees");
        }
    }
}