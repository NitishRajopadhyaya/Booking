using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.CRUD.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoFillAttribute : InputAttribute
    {
        public object DefaultValue;
        public bool HasFixedValue = false;

        public AutoFillAttribute(object value) : base("hidden")
        {
            DefaultValue = value;
            HasFixedValue = true;
        }

        public AutoFillProperty fillBy;
        public AutoFillAttribute(AutoFillProperty autofillby) : base("hidden")
        {
            fillBy = autofillby;
        }
    }

    public enum AutoFillProperty
    {
        CurrentDate, CurrentUser, CurrentCulture, CurrentStatus
    }
}
