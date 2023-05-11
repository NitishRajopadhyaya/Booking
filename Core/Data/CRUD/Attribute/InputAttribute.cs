using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.CRUD.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InputAttribute : System.Attribute
    {
        public string Input { get; set; }

        protected InputAttribute(string inputType)
        {
            Input = inputType;
        }
    }
}
