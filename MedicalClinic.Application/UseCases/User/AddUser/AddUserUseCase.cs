using AutoMapper;
using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.AddUser
{
	public sealed class AddUserUseCase : IAddUserUseCase
	{
		private readonly IUserRepository _userRepository;
		private readonly ILoginRepository _LoginRepository;
		private readonly IMapper _mapper;

		public AddUserUseCase(IMapper mapper, IUserRepository userRepository, ILoginRepository loginRepository)
		{
			_userRepository = userRepository;
			_LoginRepository = loginRepository;
			_mapper = mapper;
		}

		public async Task<Result<UserDto>> Execute(UserDto user)
		{
			var result = new Result<UserDto>();

			try
			{
				var TypeUser = user.TypeUserId == 6 ? _userRepository.GetTypeUserByName("Usuario Gerente") : _userRepository.GetTypeUser(user.UserId);
				if (TypeUser.TypeUserId != 1 && TypeUser.TypeUserId != 2)
				{
					return result = new Result<UserDto>
					{
						Message = "Erro de processamento",
						Sucess = false,
					};
				}

				var message = string.Empty;
				string value = null;

				var obj = _mapper.Map<UserDto>(user);
				UserDto userEmail = _userRepository.GetByUserEmail(user.Email);

				if (userEmail != null)
				{
					message = "Email já cadastrado!";
				}
				UserDto newUser = new UserDto();

				if (userEmail == null)
				{
					newUser.Id = await _userRepository.Add(obj);
					if (newUser.Id != 0)
					{
						user.Login.UserId = newUser.Id;
						await _LoginRepository.Add(user.Login);
					}
				}
				user.Id = newUser.Id;

				result = new Result<UserDto>
				{
					Message = userEmail != null ? message : (newUser == null ? "Erro ao inserir o Usuario" : "Ok"),
					Sucess = userEmail != null ? false : (newUser == null ? false : true),
					Data = userEmail != null ? null : (newUser == null ? null : user),

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
			}
		}
	}
}