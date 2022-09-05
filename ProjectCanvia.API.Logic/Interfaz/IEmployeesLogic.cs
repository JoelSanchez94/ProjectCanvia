using ProjectCanvia.API.DTO;
using ProjectCanvia.API.DTO.Generic;
using ProjectCanvia.API.Entity.Request;
using ProjectCanvia.API.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.Logic.Interfaz
{
	public interface IEmployeesLogic
	{
		GenericReponse<EmployeesListDTO> GetEmployees(string conexion);
		GenericReponse<ResponseEmployees> RegisterEmployees(string conexion, RequestEmployees requestEmployees);
		GenericReponse<ResponseEmployeesUpdate> UpdateEmployees(string conexion, RequestEmployeesUpdate requestEmployeesUpdate);
		GenericReponse<int> DeleteEmployees(string conexion, int employeesID); 
	}
}
