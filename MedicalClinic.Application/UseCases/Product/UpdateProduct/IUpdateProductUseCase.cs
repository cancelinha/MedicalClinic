using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.Application.UseCases.Product.UpdateProduct
{
	public interface IUpdateProductUseCase
	{
		Task<Result<UpdateProductDto>> Execute(UpdateProductDto product);
	}
}
