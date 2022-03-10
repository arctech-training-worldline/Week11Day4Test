using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Week11Day4Test.Models
{
	public class BankDetails
	{
		public string Bank { get; set; }
		public string Ifsc { get; set; }
		public string MicrCode { get; set; }
		public string Branch { get; set; }
		//public string Address { get; set; }
		public string StdCode { get; set; }
		public string Contact { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string State { get; set; }
    }
}