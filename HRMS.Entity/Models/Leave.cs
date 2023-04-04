using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("leave")]
    public class Leave
    {
        [Key]
        public int leaveid { get; set; }
        [Display(Name = "Leave Category")]
        [Required(ErrorMessage = "Please Enter Project Name")]
        public string leavename { get; set; }
        [Display(Name = "Available Leave Days")]
        [Required(ErrorMessage = "Please Enter Days")]
        public int days { get; set; }
    }
}
