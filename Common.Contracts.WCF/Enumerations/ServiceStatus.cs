﻿using System.Runtime.Serialization;

namespace Common.Contracts.WCF
{
    /// <summary>
    /// The status of a service operation
    /// </summary>
    [DataContract]
    public enum ServiceStatus
    {
        /// <summary>
        /// Operation was successfull
        /// </summary>
        [EnumMember]
        Success = 0,

        /// <summary>
        /// Not authorized to access the operation
        /// </summary>
        [EnumMember]
        NotAuthorized = 1,

        /// <summary>
        /// An error occured in the operation
        /// </summary>
        [EnumMember]
        ServiceError = 2,

        /// <summary>
        /// One or more parameters passed to the call is invalid
        /// </summary>
        [EnumMember]
        InvalidParameters = 3
    }
}
