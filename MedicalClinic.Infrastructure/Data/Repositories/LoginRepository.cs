using Dapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using MedicalClinic.Domain.MedicalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Data.Repositories
{
	public class LoginRepository : ILoginRepository
	{
        private readonly string connectionString;

        public LoginRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> Add(LoginDto login)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertLoginSQL = @"INSERT INTO [dbo].[Login] (UserId, Email, Password, Enabled, CreatedAt, UpdatedAt ) VALUES (@UserId, @Email, @Password, @Enabled, @CreatedAt, @UpdatedAt)
                SELECT CAST(SCOPE_IDENTITY() as int)";
                    DynamicParameters LoginParameters = new DynamicParameters();
                    LoginParameters.Add("@UserId", login.UserId);
                    LoginParameters.Add("@Email", login.Email);
                    LoginParameters.Add("@Password", login.Password);
                    LoginParameters.Add("@Enabled", login.Enabled);
                    LoginParameters.Add("@CreatedAt", DateTime.Now);
                    LoginParameters.Add("@UpdatedAt", DateTime.Now);
                    var id = db.QueryAsync<int>(insertLoginSQL, LoginParameters).Result;
                    return id.Single();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Login Get(string userName, string passWord)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Login where UserName = @userName and Password = @passWord";
                Entities.Login login = db
                    .QueryFirstOrDefault<Entities.Login>(sql, new { UserName = userName, Password = passWord });
                if (login == null)
                    return null;
                Login result = Login.Load(login.UserId, login.Email, login.UserName, login.Password, login.CreatedAt, login.UpdatedAt, login.Enabled, login.TotalCount);
                return result;
            }
        }
    }
}