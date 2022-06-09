using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Data.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public int TotalCount { get; set; }
        public User User { get; set; }
        public Login() { }
        public static Login Load(int userId, string userName, string email, string password, DateTime createdAt, DateTime updatedAt, bool enabled, int totalCount)
        {
            Login login = new Login();
            login.UserId = userId;
            login.UserName = userName;
            login.Email = email;
            login.Password = password;
            login.CreatedAt = createdAt;
            login.UpdatedAt = updatedAt;
            login.Enabled = enabled;
            login.TotalCount = totalCount;
            return login;
        }
    }
}

