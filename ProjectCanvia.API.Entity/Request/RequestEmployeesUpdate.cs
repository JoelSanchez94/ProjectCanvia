﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.Entity.Request
{
	public class RequestEmployeesUpdate
	{
		public int EmployeeID { get; set; }
		public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public string? Title { get; set; }
		public string? BirthDate { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
	}
}
