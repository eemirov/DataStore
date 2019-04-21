using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataStore.Web.Models
{
	public class ResponseModel
	{
		public bool IsSuccess
		{
			get { return !Errors.Any(); }
		}

		public List<Error> Errors { get; set; }

		public object Data { get; set; }

		public ResponseModel()
		{
			Errors = new List<Error>();
		}
	}

	public class Error
	{
		public string Key { get; set; }
		public string Message { get; set; }

		public Error() { }

		public Error(string key, string message)
		{
			Key = key;
			Message = message;
		}
	}
}