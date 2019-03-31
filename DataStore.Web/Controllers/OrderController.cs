using System.Collections.Generic;
using System.Web.Http;
using DataStore.Application.Services;
using DataStore.Web.Models;

namespace DataStore.Web.Controllers
{
	[RoutePrefix("api/order")]
	public class OrderController : ApiController
	{
		private readonly IDataService _dataService;

		public OrderController(IDataService dataService)
		{
			_dataService = dataService;
		}

		[Route("GetOrderData")]
		[HttpPost]
		public OrderDataModel GetOrderData()
		{
			var model = new OrderDataModel()
			{
				OrderTypes = _dataService.GetOrderTypes(),
				GenderTypes = _dataService.GetGenderTypes()
			};

			return model;
		}

		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
