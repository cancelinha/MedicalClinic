using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.GetAllUser
{
    public sealed class GetAllUserUseCase : IGetAllUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserUseCase(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Result<List<GetAllUserDto>> Execute(UserFilterDto filter)
        {
            var result = new Result<List<GetAllUserDto>>();
            try
            {
                List<GetAllUserDto> user = _userRepository.GetAll(filter);
                if (user == null || user.Count == 0)
                {
                    return result = new Result<List<GetAllUserDto>>
                    {
                        Total = 0,
                        Message = "Nenhum Usuário foi encontrado!",
                        Sucess = false
                    };
                }

                result.Data = new List<GetAllUserDto>();
                result.TotalInPage = user.Count;
                result.Message = "Consulta Ok";
                result.Sucess = true;
                user.ForEach(q =>
                {
                    result.Data.Add(new GetAllUserDto
                    {
                        Id = q.Id,
                        Name = q.Name,
                        TypeUser = q.TypeUser,
                        Email = q.Email
                    });
                    result.Total = q.TotalCount;
                });
                return result;
            }
            catch (Exception ex)
            {
                RegisterLog.Log(ex.TargetSite.DeclaringType.Namespace);
                return result = new Result<List<GetAllUserDto>>
                {
                    Message = ex.Message,
                    Sucess = false,
                };
            }
        }
    }
}