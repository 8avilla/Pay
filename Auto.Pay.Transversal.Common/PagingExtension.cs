using System;
using System.Linq;

namespace Auto.Pay.Transversal.Common
{
    public static class PagingExtension
    {
        public static DataCollection<T> GetPaged<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            var originalPages = page;

            page--;

            if (page > 0)
                page = page * take;

            DataCollection<T> result = new DataCollection<T>
            {
                Items = query.Skip(page).Take(take).ToList(),
                Total = query.Count(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
