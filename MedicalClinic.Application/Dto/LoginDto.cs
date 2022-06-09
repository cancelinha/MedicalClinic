using MedicalClinic.Domain.MedicalClinic;
using System;
using System.Text.Json.Serialization;

namespace MedicalClinic.Application.Dto
{
	public sealed class LoginDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        [JsonIgnore]
        public User User { get; }
        public LoginDto() { }

        public static LoginDto Load(int userId, string userName, string email, string password, DateTime createdAt, DateTime updatedAt, bool enabled, /*int userProfilesId,*/ int totalCount)
        {
            LoginDto login = new LoginDto();
            login.UserId = userId;
            login.UserName = userName;
            login.Email = email;
            login.Password = password;
            login.CreatedAt = createdAt;
            login.UpdatedAt = updatedAt;
            login.Enabled = enabled;
            return login;
        }

        public LoginDto(Login login)
        {
            UserId = login.UserId;
            UserName = login.UserName;
            Email = login.Email;
            Password = login.Password;
            CreatedAt = login.CreatedAt;
            UpdatedAt = login.UpdatedAt;
            Enabled = login.Enabled;
        }
    }
}