using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5Crud.Models.ViewModel
{
    public class EmployeeViewModel
    {

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "EmployeeName")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Salary shound be in 5 digit")]

        public decimal EmployeeSalary { get; set; }
        [Required]
        public string EmployeeCity { get; set; }
        [Required]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
