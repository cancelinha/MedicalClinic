using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Product.AddProduct
{
	public sealed class AddProductUseCase : IAddProductUseCase
	{
		private readonly IProductRepository _ProductRepository;
		private readonly IMapper _mapper;
		public AddProductUseCase(IMapper mapper, IProductRepository ProductRepository)
		{
			_ProductRepository = ProductRepository;
			_mapper = mapper;
		}
		public async Task<Result<ProductDto>> Execute(ProductDto Product)
		{
			var result = new Result<ProductDto>();
			try
			{
				var message = string.Empty;
				string value = null;

				var obj = _mapper.Map<ProductDto>(Product);
				ProductDto ProductName = _ProductRepository.GetByProductName(Product.Name);

				if (ProductName != null)
				{
					message = "Produto com esse Nome já cadastrado!";
				}
				ProductDto newProduct = new ProductDto();

				if (ProductName == null)
				{
					newProduct.Id = await _ProductRepository.Add(obj);
				}
				Product.Id = newProduct.Id;

				result = new Result<ProductDto>
				{
					Message = ProductName != null ? message : (newProduct == null ? "Erro ao inserir o Produto" : "Ok"),
					Sucess = ProductName != null ? false : (newProduct == null ? false : true),
					Data = ProductName != null ? null : (newProduct == null ? null : Product),
				};
				return result;
			}
			catch (Exception ex)
			{
				RegisterLog.Log(ex.TargetSite.DeclaringType.Namespace);
				return result = new Result<ProductDto>
				{
					Message = "Erro de processamento",
					Sucess = false,
				};
			}
		}
	}
}
