using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("training")]
    public class Training
    {
        [Key]
        public int trainingid { get; set; }
        [Required]
        [Display(Name ="Training")]
        public string trainingname { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }
    }
}
