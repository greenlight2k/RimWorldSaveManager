using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RimWorldSaveManager
{
	public static class Extensions
	{
		public static T GetValue<T>(this XElement element, T defaultValue = default(T))
		{
			var value = element != null ? element.Value : string.Empty;

			if (value != string.Empty)
				return (T)TypeDescriptor
					.GetConverter(typeof(T))
					.ConvertFromInvariantString(value);
			else
				return defaultValue;
		}

		public static T GetValue<T>(this XAttribute element, T defaultValue = default(T))
		{
			var value = element != null ? element.Value : string.Empty;

			if (value != string.Empty)
				return (T)TypeDescriptor
					.GetConverter(typeof(T))
					.ConvertFromInvariantString(value);
			else
				return defaultValue;
		}

		public static string GetValue(this XElement element)
		{
			return element.GetValue(string.Empty);
		}

		public static string GetValue(this XAttribute element)
		{
			return element.GetValue(string.Empty);
		}

		public static string ToTitleCase(this string str)
		{
			return Regex.Replace(str, @"\b[a-z\-]\w+", (match) =>
			{
				string v = match.ToString();
				return char.ToUpper(v[0]) + v.Substring(1);
			},
			RegexOptions.Compiled);
		}
		public static int StableStringHash(this string str)
		{
			if (str == null)
			{
				return 0;
			}
			int num = 23;
			int length = str.Length;
			for (int i = 0; i < length; i++)
			{
				num = num * 31 + str[i];
			}
			return num;
		}

		public static void TicksToPeriod(this long numTicks, out int years, out int seasons, out int days, out float hoursFloat)
		{
			years = (int)(numTicks / 3600000L);
			long num = numTicks - (long)years * 3600000L;
			seasons = (int)(num / 900000L);
			num -= (long)seasons * 900000L;
			days = (int)(num / 60000L);
			num -= (long)days * 60000L;
			hoursFloat = (float)num / 2500f;
		}
	}
}
