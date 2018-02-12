using System.Runtime.Serialization;

namespace Common.Contracts.WCF
{
    /// <summary>
    /// Lightweight model for service info
    /// </summary>
    [DataContract]
    public class ServiceInfoDTO
    {
        #region Properties

        /// <summary>
        /// Name of a property
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Version of the property
        /// </summary>
        [DataMember]
        public string Version { get; set; }

        #endregion
    }
}
