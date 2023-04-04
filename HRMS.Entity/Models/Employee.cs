﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [ForeignKey("AspNetUsers")]
        public string? employeeid { get; set; }
        [Required(ErrorMessage = "First Name Is Required!")]
        [Display(Name ="First Name")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Last Name Is Required!")]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile Number Is Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public long mobile { get; set; }
        [Display(Name = "EMail")]
        [Required(ErrorMessage = "Email Id Is Required!")]
        public string email { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Is Required!")]
        public string gender { get; set; }

        [Display(Name = "DOB")]
        [Required(ErrorMessage = "Date Of Birth Is Required!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address Is Required!")]
        public string address { get; set; }

        [ForeignKey("department")]
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department Is Required!")]
        public int departmentid { get; set; }
        [Display(Name = "Position")]
        [ForeignKey("position")]
        [Required(ErrorMessage = "Position Is Required!")]
        public int positionid { get; set; }
        [Display(Name = "Salary")]
        [ForeignKey("salary")]
        [Required(ErrorMessage = "Salary Is Required!")]
        public int salaryid { get; set; }
        public bool isdeleted { get; set; } = false;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        
        [Display(Name ="Image")]
        public string? image { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Upload Employee Image")]
        public IFormFile? imagepath { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password doesnot match")]
        public string ConfirmPassword { get; set; }



    }
}
