using System;
using System.Net;

namespace Common.WebApi
{
    /// <summary>
    /// Log data
    /// </summary>
    public class LogData
    {
        /// <summary>
        /// Correlation id
        /// Can be found all logs by one request
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Environment
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Request URI
        /// </summary>
        public string RequestUri { get; set; }

        /// <summary>
        /// HTTP method
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// Request content type
        /// </summary>
        public string RequestContentType { get; set; }

        /// <summary>
        /// Request content
        /// </summary>
        public string RequestContent { get; set; }

        /// <summary>
        /// Date of request
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Response content type
        /// </summary>
        public string ResponseContentType { get; set; }

        /// <summary>
        /// Response content
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        /// HTTP response status
        /// </summary>
        public HttpStatusCode ResponseStatusCode { get; set; }

        /// <summary>
        /// Date of response
        /// </summary>
        public DateTime ResponseDate { get; set; }
    }
}
