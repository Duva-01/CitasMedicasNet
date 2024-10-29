namespace CitasMedicasNet.Handlers
{
    using System.Net;
    using CitasMedicasNet.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    status = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case BadRequestException badRequestException:
                    status = HttpStatusCode.BadRequest;
                    message = badRequestException.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ocurrió un error inesperado. Por favor, inténtelo de nuevo.";
                    break;
            }

            // Preparar la respuesta en formato JSON
            var response = new { error = message };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
