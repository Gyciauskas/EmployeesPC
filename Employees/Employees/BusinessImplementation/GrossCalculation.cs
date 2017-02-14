using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.BusinessImplementation
{
    public class GrossCalculation
    {
        public double Count(double netSalary)
        {
            double grossSalary = 0;
            double incomeTax = 0.15;
            double healthInsurance = 0.06;
            double pensionInsurance = 0.03;

            // some comments
            if (netSalary <= 335.3)
            {
                grossSalary = (netSalary - 46.5) / (1 - (incomeTax + healthInsurance + pensionInsurance));
            }
            else if (netSalary < 760)
            {
                grossSalary = (netSalary - 75) / (1 - ((incomeTax * 1.5) + healthInsurance + pensionInsurance));
            }
            else
            {
                grossSalary = netSalary / (1 - (incomeTax + healthInsurance + pensionInsurance));
            }

            return grossSalary;
        }
    }
}