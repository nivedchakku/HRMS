using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("training_allocation")]
    public class TrainingAllocation
    {
        [Key]
        public int trainingallocationid { get; set; }
        [Required]
        public int trainingid { get; set; }
        [Required(ErrorMessage = "Select Employee")]
        public string employeeid { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        [Display(Name ="Joining Date")]
        public DateTime date { get; set; }


        [NotMapped]
        public string? firstname { get; set; }
        [NotMapped]
        public string? lastname { get; set; }
        [NotMapped]
        public Training? training { get; set; }
    }
}
