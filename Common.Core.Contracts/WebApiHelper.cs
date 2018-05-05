using System.Net;

namespace Common.Contracts
{
    /// <summary>
    /// Http helper
    /// </summary>
    public static class WebApiHelper
    {
        /// <summary>
        /// Get a normal http status from support service response
        /// </summary>
        /// <param name="serviceStatus">Service status</param>
        /// <param name="errorCode">Error code</param>
        /// <returns></returns>
        public static HttpStatusCode GetHttpStatusCodeFromServiceStatus(ServiceStatus serviceStatus, string errorCode)
        {
            switch (serviceStatus)
            {
                case ServiceStatus.Success:
                    return HttpStatusCode.OK;
                case ServiceStatus.ServiceError:
                    if (errorCode == "notFound")
                    {
                        return HttpStatusCode.NotFound;
                    }
                    return HttpStatusCode.InternalServerError;
                case ServiceStatus.NotAuthorized:
                    return HttpStatusCode.Unauthorized;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
