using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Employees.BusinessImplementation
{
    public class GrossCalculation
    {
        public double Count(double netSalary)
        {
            double baseNPD = Double.Parse(ConfigurationManager.AppSettings["baseNPD"]);
            double mmaWage = Double.Parse(ConfigurationManager.AppSettings["mmaWage"]);
            double grossSalary = 0;
            double incomeTax = Double.Parse(ConfigurationManager.AppSettings["incomeTax"]) / 100;
            double healthInsurance = Double.Parse(ConfigurationManager.AppSettings["healthInsurance"]) / 100;
            double pensionInsurance = Double.Parse(ConfigurationManager.AppSettings["pensionInsurance"]) / 100;

            if (netSalary <= 335.3)
            {
                grossSalary = (netSalary - (incomeTax * baseNPD)) / (1 - (incomeTax + healthInsurance + pensionInsurance));
            }
            else if (netSalary <= 760)
            {
                grossSalary = (netSalary - (0.15 * (baseNPD + (mmaWage / 2)))) / (1 - ((incomeTax * 1.5) + healthInsurance + pensionInsurance));
            }
            else
            {
                grossSalary = netSalary / (1 - (incomeTax + healthInsurance + pensionInsurance));
            }

            return grossSalary;
        }
    }
}