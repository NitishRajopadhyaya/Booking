using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Web
{
    public class JsonResponse : IJsonResponse
    {
        public bool Success { get; set; }

        [Description("Status code representing states of response")]
        public ResponseType ResponseType { get; set; }

        [Description("Status code representing states of response [HttpStatusCode] return to API.")]
        public int StatusCode { get; set; }

        [Description("Response message")]
        public string Message { get; set; }

        [Description("Container of responsed data")]
        public dynamic Data { get; set; }

        public dynamic Errors { get; set; }

        public async Task<JsonResponse> JsonResultAsync(bool success, ResponseType type, string msg, object data, int statusCode = 200, dynamic Errors = null)
        {
            return new JsonResponse
            {
                Success = success,
                ResponseType = type,
                Message = msg,
                Data = data,
                StatusCode = statusCode,
                Errors = Errors
            };
        }

        public JsonResponse JsonResult(bool success, ResponseType type, string msg, object data, int statusCode = 200, dynamic Errors = null)
        {
            return new JsonResponse
            {
                Success = success,
                ResponseType = type,
                Message = msg,
                Data = data,
                StatusCode = statusCode,
                Errors = Errors
            };
        }

        public JsonResponse JsonExceptionResult(string msg, object data = null, int statusCode = 500, dynamic errors = null)
        {
            return new JsonResponse
            {
                Success = false,
                ResponseType = ResponseType.Exception,
                Message = msg,
                Data = data,
                StatusCode = statusCode,
                Errors = errors
            };
        }
    }
}
