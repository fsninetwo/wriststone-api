using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wriststone.Common.Domain.Exceptions;

namespace Wriststone.Wriststone.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InternalException ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionAsync(context, ex, _configuration, HttpStatusCode.BadRequest);
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogError(ex.Message);
                var httpException = new HttpException(ex.Message, ex, HttpStatusCode.Forbidden);
                await HandleExceptionAsync(context, httpException, _configuration, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var httpException = new HttpException(ex.Message, ex, HttpStatusCode.InternalServerError);
                await HandleExceptionAsync(context, httpException, _configuration, httpException.HttpStatusCode);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, 
            IConfiguration configuration, HttpStatusCode httpCode = HttpStatusCode.InternalServerError)
        {
            var includeStackTraceResponse = configuration.GetValue<bool>("Logging:IncludeStackTraceResponse");

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)httpCode;
            }

            object errorObj;

            if (includeStackTraceResponse)
            {
                switch (exception)
                {
                    case InternalException internalException:
                        errorObj = new { error = internalException.Message, developersError = internalException.DevelopersError, stackTrace = internalException.StackTrace };
                        break;
                    default:
                        errorObj = new { error = exception.Message, stackTrace = exception.StackTrace };
                        break;
                }
            }
            else
            {
                switch (exception)
                {
                    default:
                        errorObj = new { error = exception.Message };
                        break;
                }
            }

            var result = JsonConvert.SerializeObject(errorObj);
            await context.Response.WriteAsync(result);
        }

        public class HttpException : Exception
        {
            public HttpException(string message, HttpStatusCode httpStatusCode) : base(message)
            {
                HttpStatusCode = httpStatusCode;
            }

            public HttpException(string message, Exception exception, HttpStatusCode httpStatusCode) : base(message)
            {
                HttpStatusCode = httpStatusCode;
            }

            public HttpStatusCode HttpStatusCode { get; private set; }
        }
    }
}
