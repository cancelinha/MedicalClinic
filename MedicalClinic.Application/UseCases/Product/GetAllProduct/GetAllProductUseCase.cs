using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.Application.UseCases.Product.GetAllProduct
{
    public sealed class GetAllProductUseCase : IGetAllProductUseCase
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllProductUseCase(IMapper mapper, IProductRepository ProductRepository, IUserRepository userRepository)
        {
            _ProductRepository = ProductRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Result<List<GetAllProductDto>> Execute(FilterProductDto filter)
        {
            var result = new Result<List<GetAllProductDto>>();
            try
            {
                var typeUser = _userRepository.GetTypeUser(filter.UserId);
                List<GetAllProductDto> Product = _ProductRepository.GetAll(filter);
                if(typeUser.TypeUserId != 3)
				{
                    Product = _ProductRepository.GetAllMaster(filter);
                }
                if (Product == null || Product.Count == 0)
                {
                    return result = new Result<List<GetAllProductDto>>
                    {
                        Total = 0,
                        Message = "Nenhum Produto foi encontrado!",
                        Sucess = false
                    };
                }

                result.Data = new List<GetAllProductDto>();
                result.TotalInPage = Product.Count;
                result.Message = "Consulta Ok";
                result.Sucess = true;


                Product.ForEach(q =>
                {
                    result.Data.Add(new GetAllProductDto
                    {
                        Id = q.Id,
                        Name = q.Name,
                        BatchNumber = q.BatchNumber,
                        Function = q.Function,
                        Quantity = q.Quantity,
                        Validity = q.Validity,
                        Allocated = q.Allocated,
                        CreatedAt = q.CreatedAt,
                        Enabled = q.Enabled
                    });
                    result.Total = q.TotalCount;
                });

                return result;
            }
            catch (Exception ex)
            {
                RegisterLog.Log(ex.TargetSite.DeclaringType.Namespace);
                return result = new Result<List<GetAllProductDto>>
                {
                    Message = ex.Message,
                    Sucess = false,
                };
            }

        }
    }
}
