using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Product.DeleteProduct
{
	public sealed class DeleteProductUseCase : IDeleteProductUseCase
	{
		private readonly IProductRepository _ProductRepository;
		private readonly IMapper _mapper;
		public DeleteProductUseCase(IMapper mapper, IProductRepository ProductRepository)
		{
			_ProductRepository = ProductRepository;
			_mapper = mapper;
		}
		public async Task<Result<int>> Execute(int id)
		{
			var result = new Result<int>();
			try
			{
				var resultDelete = await _ProductRepository.Delete(id);
				if (resultDelete == 0)
				{
					return result = new Result<int>
					{
						Message = "Não foi possível exluir a Produto!",
						Sucess = false,
					};
				}

				return result = new Result<int>
				{
					Message = "Produto excluido com sucesso!",
					Sucess = true,
				};

			}
			catch (System.Exception ex)
			{
				RegisterLog.Log(ex.Message, ex.TargetSite.DeclaringType.Namespace);
				return result;
			}
		}

	}
}

