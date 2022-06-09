using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.Application.Repositories
{
	public interface IProductRepository
	{
        List<GetAllProductDto> GetAll(FilterProductDto filter);
        ProductDto GetByProductName(string name);
        Task<int> Add(ProductDto product);
        Task<int> Update(UpdateProductDto product);
        Task<int> Delete(int id);
    }
}
