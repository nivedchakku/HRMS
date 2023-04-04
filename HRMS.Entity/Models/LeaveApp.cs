using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMS.Entity.Models
{
    [Table("leave_application")]
    public class LeaveApp
    {
        [Key]
        public int leaveapplyid { get; set; }
        [Display(Name = "Leave Type")]
        public int leaveid { get; set; }
        public string employeeid { get; set; }
        [Required(ErrorMessage = "Enter Start Date")]
        [Display(Name = "Start Date")]
        public DateTime startdate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]
        [Display(Name = "End Date")]
        public DateTime enddate { get; set; }
        [Required(ErrorMessage = "Enter Number of Days")]
        [Display(Name = "Required Days")]
        public int leavedays { get; set; }
        [Required(ErrorMessage = "Enter Reason")]
        [Display(Name = "Reason")]
        public string description { get; set; }
        public string status { get; set; }
        [Display(Name = "Date Applied")]

        public DateTime dateapplied { get; set; }

        [NotMapped]
        [Display(Name ="Leave Category")]
        public string? leavename { get; set; }
        [NotMapped]
        [Display(Name = "Employee")]
        public string? employeename { get; set; }
    }
}
