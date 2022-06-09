using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.GetUserLoginDetails
{
    public interface IGetUserLoginDetailsUseCase
    {
        Result<UserDto> Execute(string email, string password);
    }
}
