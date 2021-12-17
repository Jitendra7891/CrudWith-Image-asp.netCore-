using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5Crud.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="EmployeeName")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Salary shound be in 5 digit")]
        
        public double EmployeeSalary { get; set; }
        [Required]
        public string EmployeeCity { get; set; }
        [Required]
        public byte[] Image   { get; set; }
    }
}
