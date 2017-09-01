
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SampleEmailSettings.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;
            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 1;
            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query,
           IQueryObject queryObj,
           Dictionary<string, Expression<Func<T, Object>>> columnMap)
        {
            if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnMap.ContainsKey(queryObj.SortBy))
                return query;
            if (queryObj.IsSortAscending)
                return query.OrderBy(columnMap[queryObj.SortBy]);
            else
                return query.OrderBy(columnMap[queryObj.SortBy]);
        }
    }
}
