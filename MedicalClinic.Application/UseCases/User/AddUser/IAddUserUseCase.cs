using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.AddUser
{
    public interface IAddUserUseCase
    {
        Task<Result<UserDto>> Execute(UserDto user);
    }
}
