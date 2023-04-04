using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.ViewModel
{
    public class UserRollViewModel
    {
        public UserRollViewModel()
        {
            addRemoveRolesViewModel = new List<AddRemoveRolesViewModel>();
        }
        public string Id { get; set; }
        public string? UserName { get; set; }

        public List<AddRemoveRolesViewModel> addRemoveRolesViewModel { get; set; }
    }
}
