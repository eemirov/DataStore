using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Core.Enums.Attributes
{
	public class EnumStringValueAttribute : EnumBaseValueAttribute
	{
		public EnumStringValueAttribute(string value) : base(value)
		{
		}
	}
}
