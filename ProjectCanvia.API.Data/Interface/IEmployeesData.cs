using ProjectCanvia.API.DTO;
using ProjectCanvia.API.Entity.Request;
using ProjectCanvia.API.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.Data.Interface
{
	public interface IEmployeesData
	{
		List<EmployeesDTO> GetEmployees(string dsnConexion);
		int RegisterEmployee(string dsnConexion, RequestEmployees requestEmployees);
		int UpdateEmployees(string dsnConexion, RequestEmployeesUpdate requestEmployeesUpdate);
		string GetEmployeesById(string dnsConexion, int employeesID);
		int DeleteEmployee(string dsnConexion, int employeesID);

	}
}
