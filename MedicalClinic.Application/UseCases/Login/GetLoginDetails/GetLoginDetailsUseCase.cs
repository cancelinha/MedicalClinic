using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Login.GetLoginDetails
{
    public sealed class GetLoginDetailsUseCase : IGetLoginDetailsUseCase
    {
        private readonly ILoginRepository _loginRepository;

        public GetLoginDetailsUseCase(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public LoginDto Execute(string user, string senha)
        {
            LoginDto dataLogin = new LoginDto();
            var login = _loginRepository.Get(user, senha);

            if (login != null)
                dataLogin = new LoginDto(login);

            return dataLogin;
        }
    }
}
