using ProjectCanvia.API.Entity.Request;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectCanvia.API.DTO.Generic
{
	public class ValidateEmployee
	{
		public ErrorManager isValid(RequestEmployees request)
		{
			if (String.IsNullOrEmpty(request.LastName))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "El nombre es obligatorio",
					ErrorNumber = 1
				};				
			}
			if (!Regex.IsMatch(request.LastName, @"[a-zA-ZñÑ\s]{2,50}"))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "El nombre solo debe contener letras.",
					ErrorNumber = 1
				};
			}
			else if (String.IsNullOrEmpty(request.FirstName))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "El apellido es obligatorio",
					ErrorNumber = 2
				};
			}
			if (!Regex.IsMatch(request.FirstName, @"[a-zA-ZñÑ\s]{2,50}"))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "El apellido solo debe contener letras.",
					ErrorNumber = 1
				};
			}
			else if (String.IsNullOrEmpty(request.Title))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "El titulo es obligatorio",
					ErrorNumber = 3
				};
			}
			if (!Regex.IsMatch(request.Title, @"[a-zA-ZñÑ\s]{2,50}"))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "El tilulo solo debe contener letras.",
					ErrorNumber = 1
				};
			}
			else if (String.IsNullOrEmpty(request.BirthDate))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "La fecha de cumpleaños es obligatorio",
					ErrorNumber = 4
				};
			}
			else if (!DateTime.TryParseExact(request.BirthDate,"dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "La fecha no tiene el formato correcto",
					ErrorNumber = 4
				};
			}
			else if (String.IsNullOrEmpty(request.Address))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "La dirección es obligatorio",
					ErrorNumber = 5
				};
			}
			else if (String.IsNullOrEmpty(request.City))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "La Ciudad es obligatorio",
					ErrorNumber = 6
				};
			}
			if (!Regex.IsMatch(request.City, @"[a-zA-ZñÑ\s]{2,50}"))
			{
				return new ErrorManager
				{
					Status = 400,
					Descripcion = "La ciudad solo debe contener letras.",
					ErrorNumber = 1
				};
			}
			return null;
		}
	}
}
