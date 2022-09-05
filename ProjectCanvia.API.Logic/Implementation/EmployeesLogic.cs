using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjectCanvia.API.Data.Configuration;
using ProjectCanvia.API.Data.Interface;
using ProjectCanvia.API.DTO;
using ProjectCanvia.API.DTO.Generic;
using ProjectCanvia.API.Entity.Request;
using ProjectCanvia.API.Entity.Response;
using ProjectCanvia.API.Logic.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.Logic.Implementation
{
	public class EmployeesLogic : IEmployeesLogic
	{
		
		private readonly IEmployeesData _employeesData;
		private readonly ValidateEmployee _validateEmployee;
		public EmployeesLogic(IEmployeesData employeesData)
		{			
			_employeesData = employeesData;
			_validateEmployee = new ValidateEmployee();
		}

		public GenericReponse<int> DeleteEmployees(string conexion, int employeesID)
		{
			int result = -1;

			try
			{
				//Validando que el Empleado exista. 
				string employeesDTO = null;
				employeesDTO = _employeesData.GetEmployeesById(conexion, employeesID);

				if (!string.IsNullOrEmpty(employeesDTO))
				{
					result = _employeesData.DeleteEmployee(conexion, employeesID);
					if (result == 1)
					{
						return new GenericReponse<int>
						{
							Data = result,
							ErrorManager = new ErrorManager
							{
								Status = 200,
								Descripcion = "Empleado Eliminado",
								ErrorNumber = 20
							}
						};
					}
					else
					{
						return new GenericReponse<int>
						{
							Data = result,
							ErrorManager = new ErrorManager
							{
								Status = 200,
								Descripcion = "Empleado no Eliminado",
								ErrorNumber = 22
							}
						};
					}
				}
				else
				{
					return new GenericReponse<int>
					{
						Data = result,
						ErrorManager = new ErrorManager
						{
							Status = 400,
							Descripcion = "Empleado no existe.",
							ErrorNumber = 36
						}
					};
				}
			}
			catch (Exception)
			{

				return new GenericReponse<int>
				{
					Data = result,
					ErrorManager = new ErrorManager
					{
						Status = 400,
						Descripcion = "Ups Algo salio mal.",
						ErrorNumber = 64
					}
				};
			}
			
		}

		public GenericReponse<EmployeesListDTO> GetEmployees(string conexion)
		{
			List<EmployeesDTO> employees = new List<EmployeesDTO>();
			EmployeesListDTO employeesListDTO = new EmployeesListDTO();
			try
			{
				employees = _employeesData.GetEmployees(conexion);

				if (employees.Count() == 0)
				{
					return new GenericReponse<EmployeesListDTO>
					{
						Data = null,
						ErrorManager = new ErrorManager
						{
							Status = 400,
							Descripcion = "Ops! algo salio mal",
							ErrorNumber = 34
						}
					};
				}				
			}
			catch (Exception)
			{
				return new GenericReponse<EmployeesListDTO>
				{
					Data = null,
					ErrorManager = new ErrorManager
					{
						Status = 400,
						Descripcion = "Ops algo sucedio",
						ErrorNumber = 34
					}
				};
			}
			employeesListDTO.ListEmployees = employees;
			return new GenericReponse<EmployeesListDTO>
			{
				Data = employeesListDTO,
				ErrorManager = new ErrorManager
				{
					Status = 200,
					Descripcion = "Operación realizada con exito",
					ErrorNumber = 0
				}
			};
		}

		public GenericReponse<ResponseEmployeesUpdate> UpdateEmployees(string conexion, RequestEmployeesUpdate requestEmployeesUpdate)
		{
			int result = -1;
			try
			{
				//Validando que el clinte exista.

				//EmployeesDTO employeesDTO = new EmployeesDTO();
				string employeesDTO = null;
				employeesDTO = _employeesData.GetEmployeesById(conexion, requestEmployeesUpdate.EmployeeID);

				if (!String.IsNullOrEmpty(employeesDTO))
				{
					result = _employeesData.UpdateEmployees(conexion, requestEmployeesUpdate);

					if (result == 1)
					{
						ResponseEmployeesUpdate responseEmployeesUpdate = new ResponseEmployeesUpdate();
						responseEmployeesUpdate.LastName = requestEmployeesUpdate.LastName;
						responseEmployeesUpdate.FirstName = requestEmployeesUpdate.FirstName;
						responseEmployeesUpdate.Title = requestEmployeesUpdate.Title;
						responseEmployeesUpdate.BirthDate = requestEmployeesUpdate.BirthDate;
						responseEmployeesUpdate.Address = requestEmployeesUpdate.Address;
						responseEmployeesUpdate.City = requestEmployeesUpdate.City;
						responseEmployeesUpdate.Country = requestEmployeesUpdate.Country;

						return new GenericReponse<ResponseEmployeesUpdate>
						{
							Data = responseEmployeesUpdate,
							ErrorManager = new ErrorManager
							{
								Status = 200,
								Descripcion = "Empleado actualizado con exito.",
								ErrorNumber = 0
							}
						};
					}
					else
					{
						return new GenericReponse<ResponseEmployeesUpdate>
						{
							Data = null,
							ErrorManager = new ErrorManager
							{
								Status = 400,
								Descripcion = "Empleado no actualizado.",
								ErrorNumber = 34
							}
						};
					}
				}
				else
				{
					return new GenericReponse<ResponseEmployeesUpdate>
					{
						Data = null,
						ErrorManager = new ErrorManager
						{
							Status = 400,
							Descripcion = "Empleado no existe.",
							ErrorNumber = 36
						}
					};
				}

				
			}
			catch (Exception ex)
			{
				return new GenericReponse<ResponseEmployeesUpdate>
				{
					Data = null,
					ErrorManager = new ErrorManager
					{
						Status = 400,
						Descripcion = "Ops algo sucedio.",
						ErrorNumber = 34
					}
				};
			}
		}

		GenericReponse<ResponseEmployees> IEmployeesLogic.RegisterEmployees(string conexion, RequestEmployees requestEmployees)
		{
			int result = -1;
			try
			{
				var errorManager = _validateEmployee.isValid(requestEmployees);

				if (errorManager != null)
				{
					return new GenericReponse<ResponseEmployees>
					{
						Data = null,
						ErrorManager = errorManager
					};
				}
				result = _employeesData.RegisterEmployee(conexion, requestEmployees);

				if (result == 1)
				{
					ResponseEmployees response = new ResponseEmployees();
					response.LastName = requestEmployees.LastName;
					response.FirstName = requestEmployees.FirstName;
					response.Title = requestEmployees.Title;
					response.BirthDate = requestEmployees.BirthDate;
					response.Address = requestEmployees.Address;
					response.City = requestEmployees.City;

					return new GenericReponse<ResponseEmployees>
					{
						Data = response,
						ErrorManager = new ErrorManager
						{
							Status = 200,
							Descripcion = "Empleado regitrado con exito.",
							ErrorNumber = 0
						}
					};
				}
				else
				{
					return new GenericReponse<ResponseEmployees>
					{
						Data = null,
						ErrorManager = new ErrorManager
						{
							Status = 400,
							Descripcion = "Empleado no Registrado",
							ErrorNumber = 34
						}
					};
				}
			}
			catch (Exception)
			{
				return new GenericReponse<ResponseEmployees>
				{
					Data = null,
					ErrorManager = new ErrorManager
					{
						Status = 400,
						Descripcion = "Ops algo sucedio",
						ErrorNumber = 34
					}
				};
			}
			
		}
	}
}
