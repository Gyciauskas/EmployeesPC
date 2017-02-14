using CodeMash.Net;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    [CollectionName("Employees")]
    public class Employee : EntityBase
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Net Salary")]
        public double SalaryOnHands { get; set; }
    }
}