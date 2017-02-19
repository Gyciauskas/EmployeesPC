using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.BusinessContract
{
    public interface IGrossCalculation
    {
        double Count(double netSalary);
    }
}