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

namespace MedicalClinic.Infrastructure.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly string connectionString;

		public UserRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public UserDto GetByLogin(string email, string password)
		{
			try
			{
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					string sqlUser = @"SELECT * FROM [dbo].[User] as u
                                LEFT JOIN Login as l ON u.Id = l.UserId 
                                WHERE L.email = @userName and l.Password = @Password ";

					var resultUser = db.Query<UserDto>(sqlUser,
						 new[]
						 {
						 typeof(UserDto),
						 typeof(LoginDto),
						 },
						 objects =>
						 {
							 UserDto user = objects[0] as UserDto;
							 LoginDto login = objects[1] as LoginDto;
							 user.Login = login;
							 return user;
						 }
						 , splitOn: "Id", param: new { @userName = email, @Password = password });
					return resultUser.FirstOrDefault();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public UserDto GetByUserEmail(string email)
		{
			try
			{
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					var result = new UserDto();
					string sqlUserName = @"  SELECT T.Name as TypeUser,u.TypeUserId,u.Name,u.Email, l.*
									FROM [dbo].[User] as u
									LEFT JOIN Login as l ON u.Id = l.UserId 
									LEFT JOIN [dbo].[TypeUser] T on u.typeUserId = T.Id
                  					WHERE L.email =  @userEmail";

					var resultUserName = db.Query<UserDto>(sqlUserName,
						 new[]
						 {
						 typeof(UserDto),
						 typeof(LoginDto),
						 },
						 objects =>
						 {
							 UserDto user = objects[0] as UserDto;
							 LoginDto login = objects[1] as LoginDto;
							 user.Login = login;
							 return user;
						 }
						 , splitOn: "Id", param: new { @userEmail = email });
					return resultUserName.FirstOrDefault();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		public LoginDto GetByUser(string email)
		{
			{
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					string sql = @" SELECT l.Email
									FROM [dbo].[Login] as l
                                WHERE L.email = @userEmail";
					LoginDto login = db.QueryFirstOrDefault<LoginDto>(sql, new { userEmail = email });

					return login;
				}
			}
		}
		public UserDto GetTypeUser(int UserId)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				string sql = @"select a.id as TypeUserId from TypeUser a left join [dbo].[User] b on a.id = b.TypeUserId where b.id = @Id";
				UserDto UserType = db.QueryFirstOrDefault<UserDto>(sql, new { @Id = UserId });

				return UserType;
			}
		}
		public UserDto GetTypeUserByName(string UserName)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				string sql = @" select a.id as TypeUserId from TypeUser a left join [dbo].[User] b on a.id = b.TypeUserId where b.Name = @Name ";
				UserDto UserType = db.QueryFirstOrDefault<UserDto>(sql, new { @Name = UserName });

				return UserType;
			}
		}
		public async Task<int> Add(UserDto user)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				db.Open();
				using (var transactionScope = db.BeginTransaction())
				{
					try
					{
						string insertUserQuery = @"INSERT INTO [dbo].[User](Name,Email,TypeUserId,CreatedAt,UpdatedAt,enabled) 
                        VALUES (@Name,@Email, @TypeUserId,@CreatedAt,@UpdatedAt,@enabled);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

						var userId = db.Query<int>(insertUserQuery, new
						{
							Id = user.Id,
							Name = user.Name,
							TypeUserId = user.TypeUserId,
							CreatedAt = DateTime.Now,
							UpdatedAt = DateTime.Now,
							Enabled = user.Enabled,
							Email = user.Email


						}, transactionScope);

						transactionScope.Commit();
						user.Id = userId.Single();
					}
					catch (Exception ex)
					{
						transactionScope.Rollback();
						user.Id = 0;
					}
				}
				return user.Id;
			}
		}
		public async Task<int> Update(UserDto user)
		{
			using (IDbConnection db = new SqlConnection(connectionString))
			{
				db.Open();
				using (var transactionScope = db.BeginTransaction())
				{
					try
					{

						string updateUserQuery = @" UPDATE [dbo].[User] SET Name = @Name,TypeUserId = @TypeUserId, UpdatedAt = @UpdatedAt, enabled = @enabled, email = @email
                                                    WHERE Id = @Id ";

						var userId = db.Query<int>(updateUserQuery, new
						{
							Id = user.Id,
							Name = user.Name,
							TypeUserId = user.TypeUserId,
							UpdatedAt = DateTime.Now,
							enabled = user.Enabled,
							email = user.Email,
						}, transactionScope);

						transactionScope.Commit();
					}
					catch (Exception)
					{
						transactionScope.Rollback();
						user.Id = 0;
						throw;
					}
				}
				return user.Id;
			}
		}
		public List<GetAllUserDto> GetAll(UserFilterDto filter)
		{
			try
			{

				var field = string.Empty;
				Int64 num;
				if (Int64.TryParse(filter.Search.Replace(".", "").Replace("/", "").Replace("-", ""), out num))
				{
					field = "A.DocumentNumber";
				}
				else
				{
					field = "A.name";
				}

				var where = !string.IsNullOrEmpty(filter.Search) ? "WHERE A.enabled = 1 AND " + field + " like '%' + @Search + '%' " : "WHERE A.enabled = 1 ";
				using (IDbConnection db = new SqlConnection(connectionString))
				{
					string sql = @"DECLARE @PageNumber AS INT, @RowspPage AS INT 
                                   SET @PageNumber = @Pn
                                   SET @RowspPage = @Rp 
                                   SELECT ROW_NUMBER() OVER(ORDER BY A.Name) AS NUMBERUSER, A.Id, A.Name,B.Name as TypeUser, A.Email, TotalCount = Count(*) Over()  
                                   FROM [User] AS A (nolock) 
                                   LEFT JOIN TypeUser B on A.TypeUserId = B.Id "
			                       + where +
								   "ORDER BY Name " +
								   "OFFSET((@PageNumber - 1) * @RowspPage) ROWS " +
								   "FETCH NEXT @RowspPage ROWS ONLY; ";

					var result = db.Query<GetAllUserDto>(sql, new { Pn = filter.PageNumber, Rp = filter.RowsPerPage, Search = filter.Search }).ToList();
					return result;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
