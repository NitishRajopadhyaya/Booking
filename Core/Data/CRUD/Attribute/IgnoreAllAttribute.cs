using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.CRUD.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAllAttribute : System.Attribute
    {
    }
}
