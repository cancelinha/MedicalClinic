using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.Application.UseCases.Product.UpdateProduct
{
    public sealed class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public UpdateProductUseCase(IMapper mapper, IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<Result<UpdateProductDto>> Execute(UpdateProductDto Product)
        {
            var result = new Result<UpdateProductDto>();
            try
            {
                var obj = _mapper.Map<UpdateProductDto>(Product);
                int rowsAffected = await _ProductRepository.Update(obj);

                result = new Result<UpdateProductDto>
                {
                    Message = rowsAffected == 0 ? "Error" : "Updated Successfully!",
                    Sucess = rowsAffected == 0 ? false : true,
                };
                return result;
            }
            catch (Exception ex)
            {
                RegisterLog.Log(ex.TargetSite.DeclaringType.Namespace);

                return result = new Result<UpdateProductDto>
                {
                    Message = "Erro de processamento",
                    Sucess = false,
                };
            };
        }
    }
}
