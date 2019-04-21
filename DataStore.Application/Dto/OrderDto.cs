using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.Application.Enums;
using DataStore.Application.Extentions;
using DataStore.Core.Entities;

namespace DataStore.Application.Dto
{
	public class OrderDto
	{
		//public int Id { get; set; }
		//[Required(ErrorMessage = "Name is required.")]
		//public string Name { get; set; }

		//[Required(ErrorMessage = "Please select Order type.")]
		//public string Type { get; set; }

		//public EnumOrderType OrderType
		//{
		//	get { return Type.AsEnumType<EnumOrderType>(); }
		//}

		//[Required(ErrorMessage = "Order Date is required.")]
		//public DateTime Date { get; set; }

		//[Required(ErrorMessage = "Please select Gender Type")]
		//public string Gender { get; set; }
		//public EnumGender GenderType
		//{
		//	get { return Gender.AsEnumType<EnumGender>(); }
		//}

		//public bool IsActive { get; set; }

		//internal OrderDto(Order original)
		//{
		//	Id = original.Id;
		//	Name = original.Name;
		//	Type = original.Type;
		//	Date = original.Date;
		//	IsActive = original.IsActive;
		//}

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<OrderItemDto> Items { get; set; }

		public OrderDto()
		{
			Items = new List<OrderItemDto>();
		}
	}

	public class OrderItemDto
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}

}
