using Microsoft.ApplicationInsights;

namespace HPS_backoffice.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        private readonly TelemetryClient _telemetryClient;
        private readonly bool _useAzureTelemetry;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
                                                ILogger<RequestResponseLoggingMiddleware> logger,
                                                TelemetryClient telemetryClient,
                                                IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _telemetryClient = telemetryClient;
            _useAzureTelemetry = bool.Parse(configuration["Logging:UseAzureTelemetry"]);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log Request
            var request = await FormatRequest(context.Request);
            Log("Request", request);

            try
            {
                // Copy the original body stream
                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context); // Call the next middleware

                    // Log Response
                    var response = await FormatResponse(context.Response);
                    Log("Response", response);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                LogException(context, ex);
                throw; // Re-throw the exception for the global handler
            }
        }

        private void Log(string type, string message)
        {
            if (_useAzureTelemetry)
            {
                _telemetryClient.TrackTrace($"{type}: {message}");
            }
            else
            {
                _logger.LogInformation($"{type}: {message}");
            }
        }

        private void LogException(HttpContext context, Exception ex)
        {
            if (_useAzureTelemetry)
            {
                _telemetryClient.TrackException(ex);
            }
            else
            {
                _logger.LogError(ex, "Exception occurred");
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var bodyAsText = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;

            return $"HttpMethod: {request.Method}, Path: {request.Path}, Body: {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"StatusCode: {response.StatusCode}, Body: {bodyAsText}";
        }
    }

}
