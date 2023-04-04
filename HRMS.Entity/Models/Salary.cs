using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMS.Entity.Models
{
    [Table("salary")]
    public class Salary
    {
        [Key]
        [Display(Name = "Department Id")]
        public int salaryid { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Please Enter Amount")]
        public int salary { get; set; }
        [Display(Name = "Provident Fund")]
        [Required(ErrorMessage = "Please Enter PF Amount")]
        public int pf { get; set; }

        [Display(Name = "Special Allowance")]
        [Required(ErrorMessage = "Please Enter Allowance Amount")]
        public int specialallowance { get; set; }

    }
}
