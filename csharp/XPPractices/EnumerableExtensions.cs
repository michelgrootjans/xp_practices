using System.Collections.Generic;
using System.Linq;

namespace XPPractices
{
    public static class EnumerableExtensions
    {
        public static T Head<T>(this IEnumerable<T> list, int position = 0)
        {
            return position < list.Count() ? list.ElementAt(position) : default(T);
        }

        public static IEnumerable<T> Tail<T>(this IEnumerable<T> list, int offset = 1)
        {
            return offset <= list.Count() ? list.Skip(offset) : new List<T>();
        }

        public static bool Empty<T>(this IEnumerable<T> list)
        {
            return !list.Any();
        }
    }
}