using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataStore.Application.Model;
using DataStore.Application.Services;
using DataStore.Web.Models;
using Newtonsoft.Json;

namespace DataStore.Web.Controllers
{
	[RoutePrefix("api/order")]
	public class OrderController : ApiController
	{
		private readonly IOrderDataService _dataService;

		public OrderController(IOrderDataService dataService)
		{
			_dataService = dataService;
		}

		[Route("getOrderPageData")]
		[HttpPost]
		public IHttpActionResult GetOrderPageData()
		{
			var result = new ResponseModel();
			try
			{
				result.Data = new OrderDataPageModel()
				{
					OrderTypes = _dataService.GetOrderTypes(),
					GenderTypes = _dataService.GetGenderTypes()
				}; ;
			}
			catch (Exception ex)
			{
				result.Errors.Add(new Error("Common", ex.Message));
			}
			return Json(result);
		}

		[HttpPost]
		[Route("getOrderList")]
		public IHttpActionResult GetOrderList(string filter)
		{
			var result = new ResponseModel();
			try
			{
				result.Data = _dataService.OrderList(filter);
			}
			catch (Exception ex)
			{
				result.Errors.Add(new Error("Common", ex.Message));
			}
			return Json(result);
		}

		[HttpPost]
		[Route("addorupdateOrder")]
		public IHttpActionResult AddOrUpdateOrder(OrderModel item)
		{
			var result = new ResponseModel();
			
			try
			{
				if (!ModelState.IsValid)
				{
					result.Errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new Error(x.Key.Replace("item.", ""), string.Join(", ", x.Value.Errors.Select(y => y.ErrorMessage)))).ToList();
					return Json(result);
				}

				if (!result.Errors.Any())
				{
					_dataService.AddOrInsertOrder(item);
				}

			}
			catch (System.Exception ex)
			{
				result.Errors.Add(new Error("Common", ex.Message));
			}

			return Json(result);
		}

	}
}
