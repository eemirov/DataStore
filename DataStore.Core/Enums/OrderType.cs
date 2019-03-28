using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.Core.Enums.Attributes;

namespace DataStore.Core.Enums
{
	public enum OrderType
	{
		[EnumStringValue("Type 1")]
		Type1,
		[EnumStringValue("Type 2")]
		Type2,
		[EnumStringValue("Type 3")]
		Type3
	}
}
