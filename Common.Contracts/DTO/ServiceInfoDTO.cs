namespace Common.Contracts
{
    /// <summary>
    /// Lightweight model for service info
    /// </summary>
    public class ServiceInfoDTO
    {
        #region Properties

        /// <summary>
        /// Name of a property
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Version of the property
        /// </summary>
        public string Version { get; set; }

        #endregion
    }
}
