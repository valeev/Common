namespace Common.Contracts
{
    /// <summary>
    /// Http status helper
    /// </summary>
    public static class HttpStatusHelper
    {
        /// <summary>
        /// Get a normal http status from support service response
        /// </summary>
        /// <param name="serviceStatus">Service status</param>
        /// <param name="errorCode">Error code</param>
        /// <returns></returns>
        public static int GetHttpStatusCodeFromServiceStatus(ServiceStatus serviceStatus, string errorCode)
        {
            switch (serviceStatus)
            {
                case ServiceStatus.Success:
                    if (errorCode.ToLower() == "created")
                    {
                        return 201;
                    }
                    if (errorCode.ToLower() == "accepted")
                    {
                        return 202;
                    }
                    return 200;
                case ServiceStatus.ServiceError:
                    if (errorCode == "notFound")
                    {
                        return 422;
                    }
                    return 500;
                case ServiceStatus.NotAuthorized:
                    return 401;
                case ServiceStatus.InvalidParameters:
                    return 422;
                default:
                    return 500;
            }
        }
    }
}
