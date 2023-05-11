using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public static class HttpContextExtension
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static HttpContext Context => _httpContextAccessor?.HttpContext;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                return !string.IsNullOrEmpty((string)request.Headers["X-Requested-With"]) && string.Equals((string)request.Headers["X-Requested-With"], "XmlHttpRequest", StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
