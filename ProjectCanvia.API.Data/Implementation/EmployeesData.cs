using ProjectCanvia.API.Data.Interface;
using ProjectCanvia.API.DTO;
using ProjectCanvia.API.Entity.Request;
using ProjectCanvia.API.Entity.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvia.API.Data.Implementation
{
	public class EmployeesData : IEmployeesData
	{
		public int DeleteEmployee(string dsnConexion, int employeesID)
		{
			int result = -1;
			try
			{
				using (var conexion = new SqlConnection(dsnConexion))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("[dbo].[DeleteEmployees]", conexion);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.Add("@PI_EmployeeID", System.Data.SqlDbType.Int).SqlValue = employeesID;					


					result = Convert.ToInt16(cmd.ExecuteScalar());
					conexion.Close();
				}
			}
			catch (Exception ex)
			{

				throw;
			}

			return result;
		}

		public List<EmployeesDTO> GetEmployees(string dsnConexion)
		{
			EmployeesDTO data = new EmployeesDTO();
			List<EmployeesDTO> responseEmployees = new List<EmployeesDTO>();
			try
			{
				using (var conexion = new SqlConnection(dsnConexion))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("[dbo].[GetEmployees]", conexion);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					SqlDataReader reader = cmd.ExecuteReader();

					if (reader.HasRows)
					{
						while (reader.Read())
						{
							data = new EmployeesDTO();
							data.LastName = reader["LastName"].ToString();
							data.FirstName = reader["FirstName"].ToString();
							data.Title = reader["title"].ToString();
							data.BirthDate = reader["BirthDate"].ToString();
							data.Address = reader["Address"].ToString();
							data.City = reader["City"].ToString();
							responseEmployees.Add(data);
						}
					}
					reader.Close();
					conexion.Close();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			

			return responseEmployees;
		}

		public string GetEmployeesById(string dnsConexion, int employeesID)
		{			
			string? result = null;
			try
			{
				using (var conexion = new SqlConnection(dnsConexion))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("[dbo].[GetEmployeesById]", conexion);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.Add("@PI_EmployeeID", System.Data.SqlDbType.Int).SqlValue = employeesID;

					result = Convert.ToString(cmd.ExecuteScalar());

					conexion.Close();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}

		public int RegisterEmployee(string dsnConexion, RequestEmployees requestEmployees)
		{
			
			int result = -1;
			try
			{
				using (var conexion = new SqlConnection(dsnConexion))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("[dbo].[InsertEmployee]", conexion);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.Add("@PI_LASTNAME", System.Data.SqlDbType.VarChar, 10).SqlValue = requestEmployees.LastName;
					cmd.Parameters.Add("@PI_FIRSTNAME", System.Data.SqlDbType.VarChar, 10).SqlValue = requestEmployees.FirstName;
					cmd.Parameters.Add("@PI_TITLE", System.Data.SqlDbType.VarChar, 30).SqlValue = requestEmployees.Title;
					cmd.Parameters.Add("@PI_BIRTHDATE", System.Data.SqlDbType.DateTime).SqlValue = requestEmployees.BirthDate;
					cmd.Parameters.Add("@PI_ADDRESS", System.Data.SqlDbType.VarChar, 60).SqlValue = requestEmployees.Address;
					cmd.Parameters.Add("@PI_CITY", System.Data.SqlDbType.VarChar, 15).SqlValue = requestEmployees.City;


					result = Convert.ToInt16(cmd.ExecuteScalar());
					conexion.Close();
				}
			}
			catch (Exception ex)
			{

				throw;
			}

			return result;

		}

		public int UpdateEmployees(string dsnConexion, RequestEmployeesUpdate requestEmployeesUpdate)
		{
			int result = -1;
			try
			{
				using (var conexion = new SqlConnection(dsnConexion))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("[dbo].[UpdateEmployee]", conexion);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.Add("@PI_EmployeeID", System.Data.SqlDbType.Int).SqlValue = requestEmployeesUpdate.EmployeeID;
					cmd.Parameters.Add("@PI_LASTNAME", System.Data.SqlDbType.VarChar, 10).SqlValue = requestEmployeesUpdate.LastName;
					cmd.Parameters.Add("@PI_FIRSTNAME", System.Data.SqlDbType.VarChar, 10).SqlValue = requestEmployeesUpdate.FirstName;
					cmd.Parameters.Add("@PI_TITLE", System.Data.SqlDbType.VarChar,30).SqlValue = requestEmployeesUpdate.Title;
					cmd.Parameters.Add("@PI_BIRTHDATE", System.Data.SqlDbType.DateTime).SqlValue = requestEmployeesUpdate.BirthDate;
					cmd.Parameters.Add("@PI_ADDRESS", System.Data.SqlDbType.VarChar, 60).SqlValue = requestEmployeesUpdate.Address;
					cmd.Parameters.Add("@PI_CITY", System.Data.SqlDbType.VarChar, 15).SqlValue = requestEmployeesUpdate.City;
					cmd.Parameters.Add("@PI_COUNTRY", System.Data.SqlDbType.VarChar, 15).SqlValue = requestEmployeesUpdate.Country;

					result = Convert.ToInt16(cmd.ExecuteScalar());
					conexion.Close();
				}
			}
			catch (Exception ex)
			{

				throw;
			}

			return result;
		}
	}
}
