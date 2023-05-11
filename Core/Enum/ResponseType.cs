using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enum
{
    public enum ResponseType
    {
        [Description("successfully added to the database")]
        Added,
        Updated,
        Deleted,
        [Description("model validation and other validation error raised from the system")]
        ValidationError,
        [Description("Exception is raised by the system")]
        Exception,
        [Description("Unauthorized Access ")]
        PermissionDenied,
        [Description("tried to insert duplicate data wheere duplicate is not allowed")]
        Duplicate,
        [Description("Success")]
        Success,
        [Description("Failure")]
        Failure,
        [Description("Warning Message")]
        Warning
    }
}