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
    [Table("department")]
    public class Department
    {
        [Key]
        [Display(Name = "Department Id")]
        public int deptid { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please enter Department Name")]
        public string deptname { get; set; }
        [Display(Name = "Status")]

        public bool isdeleted { get; set; } = false;

    }
}
