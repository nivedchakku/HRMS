using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("project")]
    public class Project
    {
        [Key]
        public int projectid { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Please enter Project Name")]
        public string projectname { get; set; }

        [Display(Name = "Starting Date")]
        [Required(ErrorMessage = "Please Enter Project Start Date")]
        public DateTime startdate { get; set; }

        [Display(Name = "Last Date")]
        public DateTime ? enddate { get; set; }

        [Display(Name = "Project Status")]
        public string? status { get; set; }

    }
}
