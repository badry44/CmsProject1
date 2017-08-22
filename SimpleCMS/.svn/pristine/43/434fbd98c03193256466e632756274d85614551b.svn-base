using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shura.SimpleCMS.Logic
{
    public static class Extensions
    {
        /// <summary>
        /// Converts time span to readable age string
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static string ToReadableAgeString(this TimeSpan span)
        {
            return string.Format("{0:0}", span.Days / 365.25);
        }

        /// <summary>
        /// Converts time span to readable string
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static string ToReadableString(this TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} hour{1}, ", span.Hours, span.Hours == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1}, ", span.Minutes, span.Minutes == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} second{1}", span.Seconds, span.Seconds == 1 ? String.Empty : "s") : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToReadableString(this DateTime date)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        /// <summary>
        /// Gets the week number of the year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetWeekNumberOfYear(this DateTime date)
        {
            var firstDay = new DateTime(date.Year, 1, 1);
            var dfi = DateTimeFormatInfo.CurrentInfo;
            var cal = dfi.Calendar;
            return cal.GetWeekOfYear(
                date,
                CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                firstDay.DayOfWeek
            );
        }

        /// <summary>
        /// Converts integer to array of boolean
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Boolean[] ToBooleanArray(this Int32 i)
        {
            return Convert.ToString(i, 2).Select(s => s.Equals('1')).Reverse().ToArray();

            //var target = new bool[32];
            //for (int j = 0; j < 32; j++)
            //{
            //    target[j] = ((i >> j) & 1) == 1;
            //}

            //return target;

            //var bitArray = new BitArray(new[] { i });
            //var target = new bool[32];
            //bitArray.CopyTo(target, 0);
            //return target;
        }

        /// <summary>
        /// Slices Two dim array row
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
        {
            for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
            {
                yield return array[row, i];
            }
        }

        /// <summary>
        /// Slices Two dim array column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column)
        {
            for (var i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                yield return array[i, column];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromIdx"></param>
        /// <param name="toIdx"></param>
        /// <returns></returns>
        public static T[] Slice<T>(this T[] source, int fromIdx, int toIdx)
        {
            T[] ret = new T[toIdx - fromIdx + 1];
            for (int srcIdx = fromIdx, dstIdx = 0; srcIdx <= toIdx; srcIdx++)
            {
                ret[dstIdx++] = source[srcIdx];
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromIdxRank0"></param>
        /// <param name="toIdxRank0"></param>
        /// <param name="fromIdxRank1"></param>
        /// <param name="toIdxRank1"></param>
        /// <returns></returns>
        public static T[,] Slice<T>(this T[,] source, int fromIdxRank0, int toIdxRank0, int fromIdxRank1, int toIdxRank1)
        {
            T[,] ret = new T[toIdxRank0 - fromIdxRank0 + 1, toIdxRank1 - fromIdxRank1 + 1];

            for (int srcIdxRank0 = fromIdxRank0, dstIdxRank0 = 0; srcIdxRank0 <= toIdxRank0; srcIdxRank0++, dstIdxRank0++)
            {
                for (int srcIdxRank1 = fromIdxRank1, dstIdxRank1 = 0; srcIdxRank1 <= toIdxRank1; srcIdxRank1++, dstIdxRank1++)
                {
                    ret[dstIdxRank0, dstIdxRank1] = source[srcIdxRank0, srcIdxRank1];
                }
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool Between(this int num, int lower, int upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool Between(this double num, double lower, double upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool Between(this float num, float lower, float upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInstance"></param>
        /// <returns></returns>
        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectData"></param>
        /// <returns></returns>
        public static T XmlDeserializeFromString<T>(this string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectData"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object XmlDeserializeFromString(this string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="strEnumValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this string strEnumValue, TEnum defaultValue)
        {
            if (!Enum.IsDefined(typeof(TEnum), strEnumValue))
                return defaultValue;

            return (TEnum)Enum.Parse(typeof(TEnum), strEnumValue);
        }
    }
}
