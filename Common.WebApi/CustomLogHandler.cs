using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace Common.WebApi
{
    /// <summary>
    /// Custom log handler
    /// Log HTTP requests and responses
    /// </summary>
    public class CustomLogHandler : DelegatingHandler
    {
        #region Variables

        /// <summary>
        /// Correlation ID header name
        /// </summary>
        private const string CorrelationHeader = "X-Correlation-ID";

        /// <summary>
        /// Environment
        /// </summary>
        private static string _environment = ConfigurationManager.AppSettings["Environment"];

        /// <summary>
        /// Logger
        /// </summary>
        private Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// Send message wrapper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var log = BuildLogDataFromRequest(request);
            var response = await base.SendAsync(request, cancellationToken);
            response.Headers.Add(CorrelationHeader, request.GetCorrelationId().ToString());
            log = BuildLogDataFromResponse(response, log);
            _logger.Info(JsonConvert.SerializeObject(log));
            return response;
        }

        #region Helpers

        /// <summary>
        /// Form log data from request
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Log data with request info</returns>
        private LogData BuildLogDataFromRequest(HttpRequestMessage request)
        {
            var log = new LogData
            {
                Environment = _environment,
                CorrelationId = request.GetCorrelationId().ToString(),
                RequestMethod = request.Method.Method,
                RequestContentType = request.Content?.Headers?.ContentType?.MediaType,
                RequestContent = request.Content?.ReadAsStringAsync().Result,
                RequestDate = DateTime.UtcNow,
                RequestUri = request.RequestUri.ToString()
            };
            return log;
        }

        /// <summary>
        /// Build or extend log data from response
        /// </summary>
        /// <param name="response">Response</param>
        /// <param name="logData">Log data if exists</param>
        /// <returns>Log data with response info</returns>
        private LogData BuildLogDataFromResponse(HttpResponseMessage response, LogData logData = null)
        {
            if (logData == null)
            {
                logData = new LogData()
                {
                    Environment = _environment
                };
            }
            logData.ResponseStatusCode = response.StatusCode;
            logData.ResponseDate = DateTime.UtcNow;
            logData.ResponseContentType = response.Content?.Headers?.ContentType?.MediaType;
            logData.ResponseContent = response.Content?.ReadAsStringAsync().Result;
            return logData;
        }

        #endregion
    }
}
