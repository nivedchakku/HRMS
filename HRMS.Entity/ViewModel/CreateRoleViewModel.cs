﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMS.Entity.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
