using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Domain.MedicalClinic
{
    public sealed class LoginAuth : IEntity, IAggregateRoot
    {
        public string Email { get; set; }
        public string Password { get; set; }
       public LoginAuth() { }

        public static LoginAuth Load(string email, string password, int totalCount)
        {
            LoginAuth login = new LoginAuth();
            login.Email = email;
            login.Password = password;
            return login;
        }
    }
}

