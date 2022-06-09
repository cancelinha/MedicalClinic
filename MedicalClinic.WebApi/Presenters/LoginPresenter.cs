using MedicalClinic.Application.Dto;
using MedicalClinic.WebApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MedicalClinic.WebApi.Presenters
{
	public class LoginPresenter
	{
		public JsonContentResult ContentResult { get; }

		public LoginPresenter()
		{
			ContentResult = new JsonContentResult();
		}

		public void Populate(Result<LoginDto> dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
		public void Populate(UserDto dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}

		public void Populate(bool dto)
		{
			if (dto == false)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}

		public void Populate(int dto)
		{
			if (dto == 0)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}

		public void Populate(Result<UserDto> dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}


		public void Populate(Result<List<LoginDto>> dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
	}
}

