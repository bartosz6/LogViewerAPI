using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Utils
{
    public static class OrderByDirectional
    {
        public static IQueryable<TSource> OrderByWithDirection<TSource, TKey>
            (this IQueryable<TSource> source,
             string field,
             bool descending)
        {
            return descending ? source.OrderBy(field).Reverse()
                              : source.OrderBy(field);
        }
    }
}