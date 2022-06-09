﻿using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Product.AddProduct
{
	public interface IAddProductUseCase
	{
		Task<Result<ProductDto>> Execute(ProductDto user);
	}
}
