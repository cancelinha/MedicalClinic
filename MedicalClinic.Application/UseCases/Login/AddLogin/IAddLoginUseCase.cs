using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Login.AddLogin
{
    public interface IAddLoginUseCase
    {
        Task<Result<LoginDto>> Execute(LoginDto login);
    }
}
