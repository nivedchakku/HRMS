using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.ViewModel
{
    public class AddRemoveRolesViewModel
    {
        public string RollId { get; set; }
        [Display(Name ="Role Name")]
        public string RollName { get; set; }
        public bool IsSelected { get; set; }
    }
}
