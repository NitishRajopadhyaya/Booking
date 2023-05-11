using Core.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Web.Api
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        [NonAction]
        protected ApiResponse HttpResponse(int statusCode, string msg, object data)
        {
            return new ApiResponse
            {
                Code = statusCode,
                Message = msg,
                Data = data
            };
        }

        [NonAction]
        protected IJsonResponse JsonResponse(bool success, int statusCode, string msg, object data, ResponseType type)
        {
            return new JsonResponse
            {
                Success = success,
                ResponseType = type,
                Message = msg,
                Data = data,
                StatusCode = statusCode
            };
        }

        [NonAction]
        protected IJsonResponse JsonResponse(JsonResponse jsonResponse)
        {
            return new JsonResponse
            {
                Success = jsonResponse.Success,
                ResponseType = jsonResponse.ResponseType,
                Message = jsonResponse.Message,
                Data = jsonResponse.Data,
                StatusCode = jsonResponse.StatusCode
            };
        }

        [NonAction]
        public OkObjectResult OkResponse(object data, string message = "")
        {
            return Ok(JsonResponse(success: true, 200, message, data, ResponseType.Success));
        }

        [NonAction]
        public OkObjectResult OkResponse(JsonResponse response)
        {
            return Ok(response);
        }

        [NonAction]
        public ObjectResult ExceptionResponse(string message, object data = null, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            return StatusCode((int)httpStatusCode, JsonResponse(success: false, 500, message, data, ResponseType.Exception));
        }

        [NonAction]
        public ObjectResult ReturnResponse(JsonResponse response)
        {
            if (response.StatusCode == 500 || response.ResponseType == ResponseType.Exception || response.ResponseType == ResponseType.Duplicate || response.ResponseType == ResponseType.ValidationError)
            {
                return ExceptionResponse(response.Message, response.Data);
            }

            return OkResponse(response);
        }

        [NonAction]
        public NotFoundObjectResult NotFoundResponse(string message, dynamic id = null, object data = null)
        {
            return NotFound(JsonResponse(false, 404, message + ((id != null) ? string.Format(" ID:{0}", id) : ""), null, ResponseType.Failure));
        }
    }
}