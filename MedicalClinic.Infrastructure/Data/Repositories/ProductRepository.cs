using Dapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalClinic.Application.Dto.ProductDto;

namespace MedicalClinic.Infrastructure.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly string connectionString;

		public ProductRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<GetAllProductDto> GetAllMaster(FilterProductDto filter)
		{
			try
			{

				var field = string.Empty;
				Int64 num;
				var where = !string.IsNullOrEmpty(filter.Search) ? "WHERE A.enabled = 1 AND A.Name like '%' + @Search + '%' " : "WHERE A.enabled = 1 ";
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					string sql = @"DECLARE @PageNumber AS INT, @RowspPage AS INT 
                                   SET @PageNumber = @Pn
                                   SET @RowspPage = @Rp 
                                   SELECT ROW_NUMBER() OVER(ORDER BY A.Name) AS NUMBERUSER, A.*, TotalCount = Count(*) Over()  
                                   FROM [Product] AS A (nolock) "
								  + where +
								   "ORDER BY Name " +
								   "OFFSET((@PageNumber - 1) * @RowspPage) ROWS " +
								   "FETCH NEXT @RowspPage ROWS ONLY; ";

					var result = db.Query<GetAllProductDto>(sql, new { Pn = filter.PageNumber, Rp = filter.RowsPerPage, Search = filter.Search}).ToList();
					return result;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public List<GetAllProductDto> GetAll(FilterProductDto filter)
		{
			try
			{

				var field = string.Empty;
				Int64 num;
				var where = !string.IsNullOrEmpty(filter.Search) ? "WHERE A.enabled = 1 AND A.Name like '%' + @Search + '%' " : "WHERE A.enabled = 1 ";
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					string sql = @"DECLARE @PageNumber AS INT, @RowspPage AS INT 
                                   SET @PageNumber = @Pn
                                   SET @RowspPage = @Rp 
                                   SELECT ROW_NUMBER() OVER(ORDER BY A.Name) AS NUMBERUSER, A.Id, A.Name, A.BatchNumber, A.[Function], A.Allocated, A.Validity, A.CreatedAt, A.UpdatedAt, A.Enabled, TotalCount = Count(*) Over()  
                                   FROM [Product] AS A (nolock) "
								  + where +
								   "ORDER BY Name " +
								   "OFFSET((@PageNumber - 1) * @RowspPage) ROWS " +
								   "FETCH NEXT @RowspPage ROWS ONLY; ";

					var result = db.Query<GetAllProductDto>(sql, new { Pn = filter.PageNumber, Rp = filter.RowsPerPage, Search = filter.Search }).ToList();
					return result;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public ProductDto GetByProductName(string name)
		{
			try
			{
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					var result = new ProductDto();

					string sqlProductName = @"SELECT * FROM [dbo].[Product] as P
                                WHERE P.Name = @name";

					var resultProductName = db.Query<ProductDto>(sqlProductName,
						 new[]
						 {
						 typeof(ProductDto),
						 },
						 objects =>
						 {
							 ProductDto unit = objects[0] as ProductDto;

							 return unit;
						 }
						 , splitOn: "Id", param: new { @name = name });

					return resultProductName.FirstOrDefault();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
		public async Task<int> Add(ProductDto product)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				db.Open();
				using (var transactionScope = db.BeginTransaction())
				{
					try
					{
						string insertProductQuery = @"INSERT INTO [dbo].[Product](Name,BatchNumber,[Function],Allocated,Validity, Quantity,CreatedAt,UpdatedAt,enabled) 
                        VALUES (@Name,@BatchNumber,@Function,@Allocated,@Validity, @Quantity,@CreatedAt,@UpdatedAt,@enabled);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

						var productId = db.Query<int>(insertProductQuery, new
						{
							Id = product.Id,
							Name = product.Name,
							BatchNumber = product.BatchNumber,
							Function = product.Function,
							Allocated = product.Allocated,
							Validity = product.Validity,
							Quantity = product.Quantity,
							CreatedAt = DateTime.Now,
							UpdatedAt = DateTime.Now,
							Enabled = product.Enabled,


						}, transactionScope);

						transactionScope.Commit();
						product.Id = productId.Single();
					}
					catch (Exception ex)
					{
						transactionScope.Rollback();
						product.Id = 0;
					}
				}
				return product.Id;
			}
		}
		public async Task<int> Update(UpdateProductDto product)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				db.Open();
				using (var transactionScope = db.BeginTransaction())
				{
					try
					{
						string updateProductQuery = @" UPDATE [dbo].[Product] SET Name = @Name, BatchNumber = @BatchNumber, [Function] = @Function, Allocated = @Allocated,Validity = @Validity, Quantity = @Quantity, UpdatedAt = @UpdatedAt, enabled = @enabled
                                                    WHERE Id = @Id ";

						var productId = db.Query<int>(updateProductQuery, new
						{
							Id = product.Id,
							Name = product.Name,
							BatchNumber = product.BatchNumber,
							Function = product.Function,
							Validity = product.Validity,
							Quantity = product.Quantity,
							Allocated = product.Allocated,
							UpdatedAt = DateTime.Now,
							enabled = product.Enabled,
						}, transactionScope);

						transactionScope.Commit();
					}
					catch (Exception)
					{
						transactionScope.Rollback();
						product.Id = 0;
						throw;
					}
				}
				return product.Id;
			}
		}
		public async Task<int> Delete(int idProduto)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				db.Open();
				using (var transactionScope = db.BeginTransaction())
				{
					try
					{
						string select = @"Select * from [dbo].[product] where Id = @Id ";
						var selectDelete = db.Query<ProductDto>(select, new { Id = idProduto }, transactionScope).FirstOrDefault();
						transactionScope.Commit();
						if (selectDelete == null || selectDelete.Id == 0)
						{
							return idProduto = 0;
						}
					}
					catch (Exception)
					{
						transactionScope.Rollback();
						idProduto = 0;
						throw;
					}
					try
					{
						string delete = @"Delete from [dbo].[Product] WHERE Id = @Id ";
						var selectDelete = db.Query<int>(delete, new { Id = idProduto }).FirstOrDefault();
						return 1;
					}
					catch (Exception ex)
					{
						idProduto = 0;
						throw;
					}
				}
			}
		}
	}
}
