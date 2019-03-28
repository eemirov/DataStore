using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Core.Enums.Attributes
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
