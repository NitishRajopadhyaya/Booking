using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class QueryRequest
    {
        public bool KeyHasPredefinedValue { get; set; } = false;
        public bool IsKeyGuidType { get; set; } = false;
        public object Id { get; set; }
        public string QuerySql { get; set; }
        public object Parameters { get; set; }
    }
}
