using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataStore.Application.Enums;
using DataStore.Application.Extentions;
using DataStore.Application.Model.Attributes;

namespace DataStore.Application.Model
{
	public class OrderModel: IOrderModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please select Order type.")]
		[OrderField]
		public string Type { get; set; }

		public EnumOrderType OrderType
		{
			get { return Type.AsEnumType<EnumOrderType>(); }
		}

		[Required(ErrorMessage = "Order Date is required.")]
		[OrderField]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "Please select Gender Type")]
		[OrderField]
		public string Gender { get; set; }

		public EnumGender GenderType
		{
			get { return Gender.AsEnumType<EnumGender>(); }
		}

		[OrderField]
		public bool IsActive { get; set; }
	}
}