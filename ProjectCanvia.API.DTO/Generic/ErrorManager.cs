using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.DTO.Generic
{
	public class ErrorManager
	{
		[DisplayName("status")]
		[JsonProperty("status")]
		public int Status { get; set; }
		[DisplayName("errorNumber")]
		[JsonProperty("errorNumber")]
		public int ErrorNumber { get; set; }
		[DisplayName("descripcion")]
		[JsonProperty("descripcion")]
		public string? Descripcion { get; set; }
	}
}
