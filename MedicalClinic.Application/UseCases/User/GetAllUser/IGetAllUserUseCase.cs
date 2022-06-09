using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.GetAllUser
{
    public interface IGetAllUserUseCase
    {
        Result<List<GetAllUserDto>> Execute(UserFilterDto filter);
    }
}
