using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    [Table("attandance")]
    public class Attandance
    {
        [Key]
        public int id { get; set; }
        public string employeeid { get; set; }
        public DateTime date { get; set; }
       
        public string? timein { get; set; }
   
        public string? timeout { get; set; }
        public string? remarks { get; set; }
    }
}
