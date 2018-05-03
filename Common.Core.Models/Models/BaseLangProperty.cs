using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    /// <summary>
    /// Base properties for models
    /// </summary>
    public abstract class BaseLangProperty : BaseProperty
    {
        #region Properties

        /// <summary>
        /// Language code in two letters by ISO
        /// </summary>
        [StringLength(2)]
        public string Language { get; set; }

        #endregion
    }
}
