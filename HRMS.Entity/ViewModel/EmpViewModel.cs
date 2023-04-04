using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMS.Entity.ViewModel
{
    public class EmpViewModel
    {
        public string? employeeid { get; set; }
        [Required(ErrorMessage = "First Name Is Required!")]
        [Display(Name = "First Name")]
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
        [Display(Name = "Image")]
        public bool isdeleted { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string? image { get; set; }
        public Salary? salary { get; set; }
        public Department? department { get; set; }
        public Position? position { get; set; }
    }
}
