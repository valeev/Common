using System;
using System.Runtime.Serialization;

namespace Common.Contracts.WCF
{
    /// <summary>
    /// Base class for all service responses
    /// </summary>
    [DataContract]
    public class ServiceResponse
    {
        #region Properties

        /// <summary>
        /// Elapsed time
        /// </summary>
        [DataMember]
        public string ElapsedTime { get; set; }

        /// <summary>
        /// The status of the service operation
        /// </summary>
        [DataMember]
        public ServiceStatus ServiceStatus { get; set; }

        /// <summary>
        /// A code of the error if the operation was not successfull
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// A description of the error if the operation was not successfull
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceResponse()
        {

        }

        /// <summary>
        /// Default constructor with all parameters
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="serviceStatus"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        public ServiceResponse(TimeSpan elapsedTime, ServiceStatus serviceStatus, string errorCode, string errorMessage)
        {
            ElapsedTime = $"{elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}.{elapsedTime.Milliseconds:000}";
            ServiceStatus = serviceStatus;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        #endregion
    }
}
