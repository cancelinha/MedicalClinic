using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.Application.UseCases.Product.GetAllProduct
{
    public interface IGetAllProductUseCase
    {
        Result<List<GetAllProductDto>> Execute(FilterProductDto filter);
    }
}
