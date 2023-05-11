using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common.Models
{
    public class ProcReturnModel
    {
        public dynamic RowId { get; set; }
        public string ErrorMsg { get; set; }
        public dynamic Response { get; set; }
        public string ErrorFlag { get; set; }

    }
}
