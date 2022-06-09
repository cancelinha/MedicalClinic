using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Login.AddLogin
{
    public sealed class AddLoginUseCase : IAddLoginUseCase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public AddLoginUseCase(IMapper mapper, ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<Result<LoginDto>> Execute(LoginDto login)
        {
            var obj = _mapper.Map<LoginDto>(login);
            int id = await _loginRepository.Add(obj);

            login.Id = id;

            var result = new Result<LoginDto>
            {
                Message = id == 0 ? "Could not register to Login, please check!" : "Inserted successfully",
                Sucess = id == 0 ? false : true,
                Data = id == 0 ? null : login
            };

            return result;
        }
    }
}