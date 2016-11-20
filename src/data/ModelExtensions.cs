using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupClue.Data
{
    public static class ModelExtensions
    {
        const int MinimumEditReasonLength = 4;
        const int MaximumEditReasonLength = 255;
        const int MinimumSubjectLength = 1;
        const int MaximumSubjectLength = 255;
        const int MinimumBodyLength = 4;
        const int MaximumBodyLength = 60000;

        public static Int64 GetTime(this DateTime date)
        {
            Int64 retval = 0;
            var st = new DateTime(1970, 1, 1);
            TimeSpan t = (date.ToUniversalTime() - st);
            retval = (Int64)(t.TotalMilliseconds + 0.5);
            return retval;
        }

        public static double ToUnixTimestamp(this DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }


        public static List<string> SplitIntoCommaSeparatedList(this string itemsString)
        {
            return !string.IsNullOrEmpty(itemsString) ? itemsString.Split(',').ToList() : new List<string>();
        }

        public static List<Guid> SplitStringIntoGuidList(this string itemsString)
        {
            return !string.IsNullOrEmpty(itemsString) ? itemsString.Split(',').Select(x => new Guid(x)).ToList() : new List<Guid>();
        }

        public static IList<T> EmptyListIfNull<T>(this IList<T> list)
        {
            return list ?? new List<T>();
        }

        public static IList<T> EmptyListIfNull<T>(this IEnumerable<T> list)
        {
            return list == null ? new List<T>() : list.ToList();
        }

        public static void AddUnique<T>(this IList<T> list, T item)
        {
            if(!list.Contains(item))
                list.Add(item);
        }


        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null)
            {
                var knownKeys = new HashSet<TKey>();
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                    {
                        yield return element;
                    }
                }
            }
        }

        public static List<List<TSource>> SplitList<TSource>(this IEnumerable<TSource> source, int nSize)
        {
            var result = new List<List<TSource>>();
            var divisions = Math.Ceiling((double)source.Count()/nSize);
            for (var i = 0; i < divisions; i++)
            {
                result.Add(source.Skip(i * nSize).Take(nSize).ToList());
            }
            return result;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string AppendSlashToUrlIfNoneExists(this string urlString)
        {
            if (!String.IsNullOrEmpty(urlString))
            {
                urlString = urlString.Trim();
                if (!urlString.EndsWith("/"))
                {
                    urlString += "/";
                }
            }
            return urlString;
        }

    }
}
