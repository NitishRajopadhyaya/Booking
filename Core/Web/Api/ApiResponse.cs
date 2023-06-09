﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Web.Api
{
    public class ApiResponse
    {
        [Description("Status code representing states of response")]

        public int Code { get; set; }

        [Description("Response message")]
        public string Message { get; set; }

        [Description("Container of responsed data")]
        public dynamic Data { get; set; }
    }
}