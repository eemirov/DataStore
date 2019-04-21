using System;

namespace DataStore.Application.Enums.Attributes
{
	public abstract class EnumBaseValueAttribute : Attribute
	{
		public EnumBaseValueAttribute(string value)
		{
			_value = value;
		}

		private string _value;
		public string Value
		{
			get { return _value; }
		}
	}
}
