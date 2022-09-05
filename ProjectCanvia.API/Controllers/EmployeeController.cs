using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjectCanvia.API.Data.Configuration;
using ProjectCanvia.API.Data.Interface;
using ProjectCanvia.API.DTO;
using ProjectCanvia.API.DTO.Generic;
using ProjectCanvia.API.Entity.Request;
using ProjectCanvia.API.Entity.Response;
using ProjectCanvia.API.Logic.Interfaz;
//using System.Web.Http;
//using System.Web.Http.Description;

namespace ProjectCanvia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly ConfigurationConexion _conexion;
		private readonly IEmployeesLogic _employeesLogic;

		public EmployeeController(IOptions<ConfigurationConexion> conexion, IEmployeesLogic employeesLogic)
		{
			_conexion = conexion.Value;
			_employeesLogic = employeesLogic;
		}

		[HttpGet]
		[System.Web.Http.Description.ResponseType(typeof(GenericReponse<EmployeesListDTO>))]
		public ActionResult GetEmployees()
		{
			return Ok(_employeesLogic.GetEmployees(_conexion.CadenaSQL));
		}


		[HttpPost]
		[System.Web.Http.Description.ResponseType(typeof(GenericReponse<ResponseEmployees>))]
		public ActionResult RegisterEmployees(RequestEmployees request)
		{
			return Ok(_employeesLogic.RegisterEmployees(_conexion.CadenaSQL, request));
		}

		[HttpPut]
		[System.Web.Http.Description.ResponseType(typeof(GenericReponse<ResponseEmployeesUpdate>))]
		public ActionResult UpdateEmplees(RequestEmployeesUpdate requestEmployeesUpdate)
		{
			return Ok(_employeesLogic.UpdateEmployees(_conexion.CadenaSQL,requestEmployeesUpdate));
		}

		[HttpDelete]
		[System.Web.Http.Description.ResponseType(typeof(GenericReponse<string>))]
		[Route("api/[controller]/{employeesId}")]
		public ActionResult DeleteEmployees(int employeesId)
		{
			return Ok(_employeesLogic.DeleteEmployees(_conexion.CadenaSQL, employeesId));
		}
	}
}
