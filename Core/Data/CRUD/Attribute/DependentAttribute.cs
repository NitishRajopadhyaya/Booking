using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.CRUD.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DependentAttribute : System.Attribute
    {
        public string Get { get; set; }
        public Type Model { get; set; }
        public string Condition { get; set; }
    }
}
