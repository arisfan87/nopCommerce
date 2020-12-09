using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nop.Core;

namespace System.Linq
{
    public static class AsyncIQueryableExtensions
    {
        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">A sequence whose elements to test for a condition</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// true if any elements in the source sequence pass the test in the specified predicate;
        /// otherwise, false
        /// </returns>
        public static async Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate=null)
        {
            return await (predicate == null ? source.ToAsyncEnumerable().AnyAsync() : source.ToAsyncEnumerable().AnyAsync(predicate.Compile()));
        }
        
        /// <summary>
        /// Returns the number of elements in the specified sequence that satisfies a condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">An sequence that contains the elements to be counted</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// The number of elements in the sequence that satisfies the condition in the predicate
        /// function
        /// </returns>
        public static async Task<int> CountAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate = null)
        {
            return await (predicate == null ? source.ToAsyncEnumerable().CountAsync() : source.ToAsyncEnumerable().CountAsync(predicate.Compile()));
        }
        
        /// <summary>
        /// Returns the first element of a sequence that satisfies a specified condition
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">An sequence to return an element from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>The first element in source that passes the test in predicate</returns>
        public static async Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate = null)
        {
            return await (predicate == null ? source.ToAsyncEnumerable().FirstAsync() : source.ToAsyncEnumerable().FirstAsync(predicate.Compile()));
        }

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">Source</param>
        /// <param name="predicate">Predicate</param>
        /// <returns>default(TSource) if source is empty; otherwise, the first element in source</returns>
        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate = null)
        {
            return await (predicate == null ? source.ToAsyncEnumerable().FirstOrDefaultAsync() : source.ToAsyncEnumerable().FirstOrDefaultAsync(predicate.Compile()));
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition,
        /// and throws an exception if more than one such element exists
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">An sequence to return a single element from</param>
        /// <param name="predicate">A function to test an element for a condition</param>
        /// <returns>The single element of the input sequence that satisfies the condition in predicate</returns>
        public static async Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate=null)
        {
            return await (predicate == null ? source.ToAsyncEnumerable().SingleAsync() : source.ToAsyncEnumerable().SingleAsync(predicate.Compile()));
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition or
        /// a default value if no such element exists; this method throws an exception if
        /// more than one element satisfies the condition
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">A sequence to return a single element from</param>
        /// <param name="predicate">A function to test an element for a condition</param>
        /// <returns>
        /// The single element of the input sequence that satisfies the condition in predicate,
        /// or default(TSource) if no such element is found
        /// </returns>
        public static async Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate=null)
        {
            return await (predicate == null ? source.ToAsyncEnumerable().SingleOrDefaultAsync() : source.ToAsyncEnumerable().SingleOrDefaultAsync(predicate.Compile()));
        }

        #region Sum
        
        /// <summary>
        /// Computes the sum of the sequence that is obtained
        /// by invoking a projection function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">A sequence of values of type TSource</param>
        /// <param name="predicate">A projection function to apply to each element</param>
        /// <returns>The sum of the projected values</returns>
        public static async Task<decimal> SumAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, decimal>> predicate)
        {
            return await source.ToAsyncEnumerable().SumAsync(predicate.Compile());
        }

        /// <summary>
        /// Computes the sum of the sequence that is obtained
        /// by invoking a projection function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">A sequence of values of type TSource</param>
        /// <param name="predicate">A projection function to apply to each element</param>
        /// <returns>The sum of the projected values</returns>
        public static async Task<decimal?> SumAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, decimal?>> predicate)
        {
            return await source.ToAsyncEnumerable().SumAsync(predicate.Compile());
        }

        /// <summary>
        /// Computes the sum of the sequence that is obtained
        /// by invoking a projection function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">A sequence of values of type TSource</param>
        /// <param name="predicate">A projection function to apply to each element</param>
        /// <returns>The sum of the projected values</returns>
        public static async Task<double?> SumAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, double?>> predicate)
        {
            return await source.ToAsyncEnumerable().SumAsync(predicate.Compile());
        }
        
        /// <summary>
        /// Computes the sum of the sequence that is obtained
        /// by invoking a projection function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">A sequence of values of type TSource</param>
        /// <param name="predicate">A projection function to apply to each element</param>
        /// <returns>The sum of the projected values</returns>
        public static async Task<int> SumAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, int>> predicate)
        {
            return await source.ToAsyncEnumerable().SumAsync(predicate.Compile());
        }

        /// <summary>
        /// Computes the sum of the sequence that is obtained
        /// by invoking a projection function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">A sequence of values of type TSource</param>
        /// <param name="predicate">A projection function to apply to each element</param>
        /// <returns>The sum of the projected values</returns>
        public static async Task<int?> SumAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, int?>> predicate)
        {
            return await source.ToAsyncEnumerable().SumAsync(predicate.Compile());
        }

        #endregion

        /// <summary>
        /// Asynchronously loads data from query to an array
        /// </summary>
        /// <typeparam name="TSource">Query element type</typeparam>
        /// <param name="source">Source query</param>
        /// <returns>Array with query results</returns>
        public static async Task<TSource[]> ToArrayAsync<TSource>(this IQueryable<TSource> source)
        {
            return await source.ToAsyncEnumerable().ToArrayAsync();
        }

        /// <summary>
        /// Asynchronously loads data from query to a dictionary
        /// </summary>
        /// <typeparam name="TSource">Query element type</typeparam>
        /// <typeparam name="TKey">Dictionary key type</typeparam>
        /// <typeparam name="TElement">Dictionary element type</typeparam>
        /// <param name="source">Source query</param>
        /// <param name="keySelector">Source element key selector</param>
        /// <param name="elementSelector">Dictionary element selector</param>
        /// <param name="comparer">Dictionary key comparer</param>
        /// <returns>Dictionary with query results</returns>
        public static async Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            this IQueryable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer = null) where TKey : notnull
        {
            return await (comparer == null
                ? source.ToAsyncEnumerable().ToDictionaryAsync(keySelector, elementSelector)
                : source.ToAsyncEnumerable().ToDictionaryAsync(keySelector, elementSelector, comparer));
        }
        
        /// <summary>
        /// Asynchronously loads data from query to a list
        /// </summary>
        /// <typeparam name="TSource">Query element type</typeparam>
        /// <param name="source">Source query</param>
        /// <returns>List with query results</returns>
        public static async Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source)
        {
            return await source.ToAsyncEnumerable().ToListAsync();
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records. Set to "true" if you don't want to load data from database</param>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            if (source == null)
                return new PagedList<T>(new List<T>(), pageIndex, pageSize);

            var count = await source.CountAsync();

            var data = new List<T>();

            if (!getOnlyTotalCount)
                data.AddRange(await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());

            return new PagedList<T>(data, pageIndex, pageSize, count);
        }
    }
}
