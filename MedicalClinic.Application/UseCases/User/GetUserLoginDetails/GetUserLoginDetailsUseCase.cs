using MedicalClinic.Application.Dto;
using MedicalClinic.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.User.GetUserLoginDetails
{
	public sealed class GetUserLoginDetailsUseCase : IGetUserLoginDetailsUseCase
	{
		private readonly IUserRepository _userRepository;

		public GetUserLoginDetailsUseCase(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		Result<UserDto> result = new Result<UserDto>();
		public Result<UserDto> Execute(string email, string password)
		{
			try
			{
				UserDto user = new UserDto();
				UserDto userEmail = _userRepository.GetByUserEmail(email);
				if (userEmail.Login.Email != null)
				{
					user = _userRepository.GetByLogin(email, password);
				}
				result = new Result<UserDto>
				{
					Message = userEmail == null ? "Usuário incorreto" : (user == null ? "Acesso invalido" : "Ok"),
					Sucess = userEmail == null ? false : (user == null ? false : true),
					Data = userEmail == null ? userEmail : (user == null ? user : user),
					Code = userEmail.Login.Email == null ? "USER_DOES_NOT_EXISTS" : (user == null ? "INCORRECT_PASSWORD" : "SUCCESS"),
					Id = userEmail == null ? 0 : (user == null ? 0 : user.Id),
					TypeUserId = userEmail == null ? 0 : (userEmail == null ? 0 : userEmail.TypeUserId),
					TypeUser = userEmail == null ? "" : (userEmail == null ? "" : userEmail.TypeUser),
					Name = userEmail == null ? "" : (userEmail == null ? "" : userEmail.Name),

				};
				return result;
			}
			catch (Exception ex)
			{
				RegisterLog.Log(ex.TargetSite.DeclaringType.Namespace);
				LoadError();
				return result;
			}
		}

		void LoadError()
		{
			result = new Result<UserDto>
			{
				Message = "Erro de processamento",
				Sucess = false,
			};
		}
	}
}

