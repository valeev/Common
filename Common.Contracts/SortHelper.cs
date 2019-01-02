using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Contracts
{
    /// <summary>
    /// Sorting helper
    /// </summary>
    public static class SortHelper
    {
        /// <summary>
        /// Sort records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public static IQueryable<T> Sort<T>(IQueryable<T> records, string sortBy)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return records;
            }
            var sortingArray = sortBy.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            if (sortingArray.Length < 1 || sortingArray.Length > 2)
            {
                return records;
            }
            if (sortingArray.Length == 1 || (sortingArray.Length == 2 && sortingArray[1].ToLower() == "asc"))
            {
                records = OrderingHelper(records, sortingArray[0].ToLower(), false);
            }
            else if (sortingArray.Length == 2 && sortingArray[1].ToLower() == "desc")
            {
                records = OrderingHelper(records, sortingArray[0].ToLower(), true);
            }
            return records;
        }

        #region Helpers

        /// <summary>
        /// Ordering helper
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records"></param>
        /// <param name="propertyName"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> records, string propertyName, bool descending)
        {
            var param = Expression.Parameter(typeof(T), string.Empty);
            var property = Expression.PropertyOrField(param, propertyName);
            var sort = Expression.Lambda(property, param);
            var call = Expression.Call(
                typeof(Queryable), "OrderBy" + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                records.Expression,
                Expression.Quote(sort));
            return (IOrderedQueryable<T>)records.Provider.CreateQuery<T>(call);
        }

        #endregion
    }
}
