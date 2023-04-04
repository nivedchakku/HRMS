using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("project_allocation")]
    public class ProjectAllocation
    {
        [Key]
        public int allocationid { get; set; }
        [Required]
        public int projectid { get; set; }
        [Required(ErrorMessage ="Select Employee")]
        public string employeeid { get; set; }
        [Required]
        public string status { get; set; }
        public DateTime allocationdate { get; set; }

        [NotMapped]
        public string? projectname { get; set; }
        [NotMapped]
        public string? firstname { get; set; }
        [NotMapped]
        public string? lastname { get; set; }
    }
}
