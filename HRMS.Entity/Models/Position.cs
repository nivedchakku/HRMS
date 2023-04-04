using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("position")]
    public class Position
    {
        [Key]
        public int positionid { get; set; }

        [Display(Name = "Position Name")]
        [Required(ErrorMessage = "Please enter Position Name")]
        public string positionname { get; set; }
        [Display(Name = "Status")]

        public bool isdeleted { get; set; } = false;

    }
}
