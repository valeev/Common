namespace Common.Models
{
    /// <summary>
    /// Interface for the unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save pending changes to the data store.
        /// </summary>
        void Commit();
    }
}
