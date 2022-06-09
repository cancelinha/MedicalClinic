using MedicalClinic.Application.Dto;
using MedicalClinic.Application.UseCases.Product.AddProduct;
using MedicalClinic.Application.UseCases.Product.DeleteProduct;
using MedicalClinic.Application.UseCases.Product.GetAllProduct;
using MedicalClinic.Application.UseCases.Product.UpdateProduct;
using MedicalClinic.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IAddProductUseCase _addProductUseCase;
		private readonly ProductPresenter _productPresenter;
		private readonly IUpdateProductUseCase _updateProductUseCase;
		private readonly IDeleteProductUseCase _deleteProductUseCase;
		private readonly IGetAllProductUseCase _getAllProductUseCase;
		public ProductController(
			ProductPresenter productPresenter,
			IAddProductUseCase addProductUseCase,
			IUpdateProductUseCase updateProductUseCase,
			IDeleteProductUseCase deleteProductUseCase,
			IGetAllProductUseCase getAllProductUseCase)

		{
			_addProductUseCase = addProductUseCase;
			_productPresenter = productPresenter;
			_updateProductUseCase = updateProductUseCase;
			_deleteProductUseCase = deleteProductUseCase;
			_getAllProductUseCase = getAllProductUseCase;
		}
		/// <summary>
		/// Add an Product
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> Add(ProductDto Product)

		{
			Result<ProductDto> output = await _addProductUseCase.Execute(Product);
			_productPresenter.GetPopulateFirst(output);
			return _productPresenter.ContentResult;
		}

		/// <summary>
		/// Alter an Product
		/// </summary>
		[HttpPut]
		public async Task<IActionResult> Update(UpdateProductDto Product)
		{
			Result<UpdateProductDto> output = await _updateProductUseCase.Execute(Product);
			return Ok(output);
		}

		/// <summary>
		/// Get an Product
		/// </summary>

		[HttpPost("GetAllProduct")]
		public async Task<IActionResult> All(FilterProductDto filter)
		{
			Result<List<GetAllProductDto>> output = _getAllProductUseCase.Execute(filter);
			_productPresenter.Populate(output);
			return _productPresenter.ContentResult;
		}
		/// <summary>
		/// Delete an Product
		/// </summary>
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			Result<int> output = await _deleteProductUseCase.Execute(id);
			_productPresenter.GetPopulateFirst(output);
			return _productPresenter.ContentResult;
		}

	}
}
