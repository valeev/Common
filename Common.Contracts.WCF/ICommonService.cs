using System.ServiceModel;

namespace Common.Contracts.WCF
{
    /// <summary>
    /// Common interface for all WCF services
    /// </summary>
    [ServiceContract]
    public interface ICommonService
    {
        /// <summary>
        /// Return current service info
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetServiceInfoResponse GetServiceInfo(GetServiceInfoRequest request);
    }
}
