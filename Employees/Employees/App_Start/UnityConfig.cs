using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Employees.BusinessContract;
using Employees.BusinessImplementation;

namespace Employees
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IEmployeeService, EmployeeService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}