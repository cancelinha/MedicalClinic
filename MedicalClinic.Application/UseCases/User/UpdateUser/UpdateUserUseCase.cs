using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.UpdateUser
{
    public sealed class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Execute(UserDto user)
        {
            var result = new Result<UserDto>();

            try
            {
                UserDto type = _userRepository.GetTypeUser(user.UserId);

                if (type.TypeUserId != 1 && type.TypeUserId != 2)
                {
                    return result = new Result<UserDto>
                    {
                        Message = "Erro de processamento",
                        Sucess = false,
                    };
                }

                var obj = _mapper.Map<UserDto>(user);
                int rowsAffected = await _userRepository.Update(obj);

                result = new Result<UserDto>
                {
                    Message = rowsAffected == 0 ? "Error" : "Updated Successfully!",
                    Sucess = rowsAffected == 0 ? false : true,
                };

                return result;
            }
            catch (Exception ex)
            {
                RegisterLog.Log(ex.TargetSite.DeclaringType.Namespace);

                return result = new Result<UserDto>
                {
                    Message = "Erro de processamento",
                    Sucess = false,
                };
            };
        }
    }
}
