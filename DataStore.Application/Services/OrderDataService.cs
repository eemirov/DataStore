using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DataStore.Application.Dto;
using DataStore.Application.Enums;
using DataStore.Application.Extentions;
using DataStore.Application.Model;
using DataStore.Application.Model.Attributes;
using DataStore.Core.Data;
using DataStore.Core.Entities;

namespace DataStore.Application.Services
{
	public class OrderDataService: IOrderDataService
	{
		private readonly IRepository<Order> _orderRepository;
		private readonly IRepository<OrderItem> _orderItemRepository;

		public OrderDataService(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
		{
			_orderRepository = orderRepository;
			_orderItemRepository = orderItemRepository;
		}

		#region Public methods
		public ICollection<EnumOptionItem> GetOrderTypes()
		{
			return Enum<EnumOrderType>.ToOptionsList(true);
		}

		public ICollection<EnumOptionItem> GetGenderTypes()
		{
			return Enum<EnumGender>.ToOptionsList();
		}

		public void AddOrInsertOrder(IOrderModel item)
		{
			Order dbItem = null;
			if (item.Id > 0)
			{
				dbItem = _orderRepository.GetById(item.Id);

				UpdateOrder(dbItem, item);
				_orderRepository.Update(dbItem);
			}
			else
			{
				dbItem = new Order();

				UpdateOrder(dbItem, item);
				_orderRepository.Insert(dbItem);
			}

			SaveOrderItems(dbItem);
		}

		public void DeleteOrder(int id)
		{
			var dbItem = _orderRepository.GetById(id);
			if(dbItem != null)
				_orderRepository.Delete(dbItem);
		}

		public ICollection<IOrderModel> OrderList(string filter)
		{
			return _orderRepository.GetAll()
			.Where(x => string.IsNullOrEmpty(filter) ||  x.Name.ToLower().Contains(filter.ToLower()))
			.AsEnumerable()
			.Select(TransformOrderModel)
			.ToList();
		}
		#endregion

		#region Private methods

		private void SaveOrderItems(Order order)
		{
			foreach (var orderItem in order.OrderItems)
			{
				var i = _orderItemRepository.GetById(orderItem.Id);
				if (i.Id > 0)
					_orderItemRepository.Update(i);
				else
					_orderItemRepository.Insert(i);
			}
		}

		private EnumDataValueType GetValueType(object value)
		{
			if (value is string)
				return EnumDataValueType.String;
			if (value is DateTime)
				return EnumDataValueType.Date;
			if (value is bool)
				return EnumDataValueType.Boolean;

			throw new Exception("Not supported type");
		}

		private string GetStringValue(object value, EnumDataValueType valueType)
		{
			switch (valueType)
			{
				case EnumDataValueType.String:
					return value.ToString();
				case EnumDataValueType.Date:
					return ((DateTime) value).ToString("dd-MMM-yyyy");
				case EnumDataValueType.Boolean:
					return ((bool) value).ToString();
			}

			throw new Exception("Not supported type");
		}

		private object GetObjectValue(string value, EnumDataValueType valueType)
		{
			switch (valueType)
			{
				case EnumDataValueType.String:
					return value;
				case EnumDataValueType.Date:
					return DateTime.Parse(value);
				case EnumDataValueType.Boolean:
					return bool.Parse(value);
			}
			throw new Exception("Not supported type");
		}

		private IOrderModel TransformOrderModel(Order order)
		{
			var item = new OrderModel
			{
				Name = order.Name
			};

			foreach (var orderItem in order.OrderItems)
			{
				var prop = item.GetType().GetProperty(orderItem.Name);
				var valueType = orderItem.ValueType.AsEnumType<EnumDataValueType>();
				if(prop != null)
					prop.SetValue(item, GetObjectValue(orderItem.Value, valueType));
			}

			return item;
		}

		private void UpdateOrder(Order order, IOrderModel dto)
		{
			order.Name = dto.Name;
			var properties = dto.GetType().GetProperties();
			foreach (var prop in properties)
			{
				var value = prop.GetValue(dto);
				if (prop.CustomAttributes.Any(p => p.AttributeType == typeof(OrderFieldAttribute)))
				{
					var valueType = GetValueType(value);
					order.OrderItems.Add(
						new OrderItem()
						{
							OrderId = order.Id,
							Name = prop.Name,
							Value = GetStringValue(value, valueType),
							ValueType = valueType.ToString()
						}
					);
				}
			}
		}
		#endregion
	}
}