using MedicalClinic.Application.Dto;
using MedicalClinic.WebApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.WebApi.Presenters
{
	public class ProductPresenter
	{

		public JsonContentResult ContentResult { get; }

		public ProductPresenter()
		{
			ContentResult = new JsonContentResult();
		}

		public void PopulateFirst(ProductDto dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}

		public void GetPopulateFirst(Result<UpdateProductDto> dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
		public void GetPopulateFirst(Result<int> dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
		public void GetPopulateFirst(Result<ProductDto> dto)
		{
			if (dto == null)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
		public void Populate(Result<List<ProductDto>> dto)
		{
			if (dto.Data == null)
			{
				//ContentResult.StatusCode = (int)(HttpStatusCode.NotFound);
				ContentResult.Content = JsonSerializer.SerializeObject(dto);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}

		public void Populate(Result<List<GetAllProductDto>> dto)
		{
			if (dto.Data == null)
			{
				//ContentResult.StatusCode = (int)(HttpStatusCode.NotFound);
				ContentResult.Content = JsonSerializer.SerializeObject(dto);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
		public void Populate(Result<ProductDto> dto)
		{
			if (dto.Sucess == false)
			{
				ContentResult.StatusCode = (int)(HttpStatusCode.BadRequest);
				ContentResult.Content = JsonSerializer.SerializeObject(dto);
				return;
			}

			ContentResult.StatusCode = (int)(HttpStatusCode.OK);
			ContentResult.Content = JsonSerializer.SerializeObject(dto);
		}
	}
}