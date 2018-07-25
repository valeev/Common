using System;
using System.Linq;
using System.Reflection;

namespace Common.Core.Contracts
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
            if (sortingArray.Length == 1 || sortingArray[1].ToLower() == "asc")
            {
                records = (from r in records
                           orderby GetDynamicSortProperty(r, sortingArray[0].ToLower()) ascending
                           select r).AsQueryable();
            }
            else if (sortingArray.Length == 2 || sortingArray[1].ToLower() == "desc")
            {
                records = (from r in records
                           orderby GetDynamicSortProperty(r, sortingArray[0].ToLower()) descending
                           select r).AsQueryable();
            }
            return records;
        }

        #region Helpers

        /// <summary>
        /// Get property
        /// </summary>
        /// <returns></returns>
        private static object GetDynamicSortProperty(object record, string propName)
        {
            //Use reflection to get order type
            return record.GetType().GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(record, null);
        }

        #endregion
    }
}
