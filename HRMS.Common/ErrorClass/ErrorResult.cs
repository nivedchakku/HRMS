using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Common.ErrorClass
{
    public class ErrorResult<T>
    {
        public T Item { get; set; }
        public string ErrorMessage { get; set; }
    }
}
