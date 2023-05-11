using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Web
{
    public interface IJsonResponse
    {
        Task<JsonResponse> JsonResultAsync(bool success, ResponseType type, string msg, object data, int statusCode = 200, dynamic Errors = null);

        JsonResponse JsonResult(bool success, ResponseType type, string msg, object data, int statusCode = 200, dynamic Errors = null);

        JsonResponse JsonExceptionResult(string msg, object data = null, int statusCode = 500, dynamic Errors = null);
    }
}
