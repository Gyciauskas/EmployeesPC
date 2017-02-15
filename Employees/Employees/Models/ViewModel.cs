using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class ViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Net Salary")]
        public double SalaryOnHands { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Gross Salary")]
        public double SalaryOnPaper { get; set; }

        public string Id { get; set; }
    }
}