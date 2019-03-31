using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.Core.Enums.Attributes;

namespace DataStore.Core.Enums
{
	public enum EnumGender {
		[EnumStringValue("Male")]
		Male,
		[EnumStringValue("Female")]
		Female
	}
}
