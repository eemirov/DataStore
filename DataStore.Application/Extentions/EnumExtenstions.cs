using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DataStore.Application.Enums.Attributes;

namespace DataStore.Application.Extentions
{
	public static class EnumExtenstions
	{
		/// <summary>
		/// Gets EnumStringValue attribute
		/// </summary>
		public static string ToStringValue(this System.Enum value)
		{
			string output = string.Empty;
			Type type = value.GetType();

			FieldInfo fi = type.GetField(value.ToString());
			EnumStringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(EnumStringValueAttribute), false) as EnumStringValueAttribute[];
			if (attrs != null && attrs.Length > 0)
			{
				output = attrs[0].Value;
			}

			return output;
		}

		/// <summary>
		/// Gets Enum from EnumStringValue attribute
		/// </summary>
		public static T AsEnum<T>(this string value) where T : struct
		{
			if (value == null)
				return default(T);

			if (!typeof(T).IsEnum)
				return default(T);

			var names = System.Enum.GetNames(typeof(T));
			foreach (var enumName in names)
			{
				var e = (T)System.Enum.Parse(typeof(T), enumName);
				var stringValue = ToStringValue(e as System.Enum);
				if ((!string.IsNullOrEmpty(stringValue) ? stringValue : e.ToString()).ToLower() == value.ToLower())
					return e;
			}

			return default(T);
		}

		/// <summary>
		/// Gets Enum from string value
		/// </summary>
		public static T AsEnumType<T>(this string value) where T : struct
		{
			if (value == null)
				return default(T);

			if (!typeof(T).IsEnum)
				return default(T);

			var names = System.Enum.GetNames(typeof(T));
			foreach (var enumName in names)
			{
				var e = (T)System.Enum.Parse(typeof(T), enumName);
				if (e.ToString().ToLower() == value.ToLower())
					return e;
			}

			return default(T);
		}
	}

	public class EnumOptionItem
	{
		public string Value { get; set; }
		public string Text { get; set; }
	}

	public static class Enum<T>
	{
		public static List<EnumOptionItem> ToOptionsList(bool addEmpty = false, bool order = true)
		{
			var list = new List<EnumOptionItem>();
			if (!typeof(T).IsEnum)
				return list;

			if (addEmpty)
				list.Add(new EnumOptionItem());

			foreach (var s in System.Enum.GetNames(typeof(T)))
			{
				var t = (System.Enum)System.Enum.Parse(typeof(T), s);
				list.Add(new EnumOptionItem()
				{
					Value = t.ToString(),
					Text = t.ToStringValue(),
				});
			}

			if (order)
				return list.OrderBy(x => x.Text).ToList();

			return list;
		}
	}

}
