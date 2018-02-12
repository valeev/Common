﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Contracts.WCF
{
    /// <summary>
    /// Response to getting service info
    /// </summary>
    [DataContract]
    public class GetServiceInfoResponse : ServiceResponse
    {
        #region Properties

        /// <summary>
        /// Service information list
        /// </summary>
        [DataMember]
        public ICollection<ServiceInfoDTO> Informations { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="informations">Informations</param>
        /// <param name="elapsedTime">Elapsed time</param>
        /// <param name="serviceStatus">ServiceStatus</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        public GetServiceInfoResponse(ICollection<ServiceInfoDTO> informations, TimeSpan elapsedTime, ServiceStatus serviceStatus, string errorCode = "", string errorMessage = "")
                                     : base(elapsedTime, serviceStatus, errorCode, errorMessage)
        {
            Informations = informations;
        }

        #endregion
    }
}
