using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.DTO.Generic
{
	public class GenericReponse<T>
	{
		[DisplayName("data")]
		[JsonProperty("data")]
		public T Data { get; set; }
		[DisplayName("errorManager")]
		[JsonProperty("errorManager")]
		public ErrorManager ErrorManager { get; set; }
	}
}
