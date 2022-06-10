using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Dto
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string BatchNumber { get; set; }
		public string Function { get; set; }
		public bool Allocated { get; set; }
		public DateTime Validity { get; set; }
		public int Quantity { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Enabled { get; set; }
		public int TotalCount { get; set; }
		public ProductDto() { }

		public static ProductDto Load(int id, string name, string batchNumber, string function, bool allocated,DateTime valid,int quant, DateTime createdAt, DateTime updatedAt, bool enabled, int totalCount)
		{
			ProductDto product = new ProductDto();
			product.Id = id;
			product.Name = name;
			product.BatchNumber = batchNumber;
			product.Validity = valid;
			product.Quantity = quant;
			product.Function = function;
			product.Allocated = allocated;
			product.CreatedAt = createdAt;
			product.UpdatedAt = updatedAt;
			product.Enabled = enabled;
			product.TotalCount = totalCount;
			return product;
		}
		public sealed class FilterProductDto
		{
			public int UserId { get; set; }
			public string Search { get; set; }
			public int PageNumber { get; set; }
			public int RowsPerPage { get; set; }


			public FilterProductDto() { }

			public FilterProductDto(int userId, string search, int pageNumber, int rowsPerPage)
			{
				FilterProductDto filter = new FilterProductDto();

				filter.UserId = userId;
				filter.Search = search;
				filter.PageNumber = pageNumber;
				filter.RowsPerPage = rowsPerPage;

			}
		}

		public sealed class UpdateProductDto
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string BatchNumber { get; set; }
			public string Function { get; set; }
			public bool Allocated { get; set; }
			public DateTime Validity { get; set; }
			public int Quantity { get; set; }
			public DateTime UpdatedAt { get; set; }
			public bool Enabled { get; set; }
			public int TotalCount { get; set; }
			public int UserId { get; set; }

			[JsonIgnore]
			public ProductDto ProductDto { get; set; }

			public UpdateProductDto() { }

			public static UpdateProductDto Load(int id, string name, string batchNumber, DateTime valid, int quant, string function, bool allocated, DateTime updatedAt, bool enabled, int totalCount)

			{
				UpdateProductDto product = new UpdateProductDto();
				product.Id = id;
				product.Name = name;
				product.BatchNumber = batchNumber;
				product.Function = function;
				product.Allocated = allocated;
				product.Validity = valid;
				product.Quantity = quant;
				product.UpdatedAt = updatedAt;
				product.Enabled = enabled;
				product.TotalCount = totalCount;

				return product;

			}
		}
	}
	public sealed class GetAllProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string BatchNumber { get; set; }
		public string Function { get; set; }
		public bool Allocated { get; set; }
		public DateTime Validity { get; set; }
		public int Quantity { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Enabled { get; set; }
		public int TotalCount { get; set; }


		public GetAllProductDto() { }

		public static GetAllProductDto Load( string name, string batchNumber, string function, bool allocated, DateTime valid, int quant, DateTime updatedAt, DateTime createdAt, bool enabled, int totalCount)

		{
			GetAllProductDto product = new GetAllProductDto();
			product.Name = name;
			product.BatchNumber = batchNumber;
			product.Function = function;
			product.Allocated = allocated;
			product.Validity = valid;
			product.Quantity = quant;
			product.CreatedAt = createdAt;
			product.UpdatedAt = updatedAt;
			product.Enabled = enabled;
			product.TotalCount = totalCount;

			return product;

		}
	}
}

