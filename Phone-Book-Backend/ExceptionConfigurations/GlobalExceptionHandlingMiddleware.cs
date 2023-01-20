using PhoneBook.Exceptions;
using System.Net;
using System.Text.Json;
using NotImplementedException = PhoneBook.Exceptions.NotImplementedException;

namespace Phone_Book_Backend.ExceptionConfigurations
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public GlobalExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var strackTrace = string.Empty;
            string message = "";
            var exceptionType = exception.GetType();
            if (exceptionType == typeof(ContactNotFoundException))
            {
                status = HttpStatusCode.NotFound;
                message = exception.Message;
                strackTrace = exception.StackTrace;
            }else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                strackTrace = exception.StackTrace;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                strackTrace = exception.StackTrace;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message, strackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);

        }






    }
}
