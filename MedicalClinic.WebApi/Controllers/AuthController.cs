using MedicalClinic.Application.UseCases.Login.GetLoginDetails;
using MedicalClinic.Application.UseCases.User.GetUserLoginDetails;
using MedicalClinic.Domain.MedicalClinic;
using MedicalClinic.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IGetUserLoginDetailsUseCase _getUserLoginDetailsUseCase;
		private readonly IGetLoginDetailsUseCase _getLoginDetailsUseCase;
		private readonly LoginPresenter _loginPresenter;
		public AuthController(

		   IGetUserLoginDetailsUseCase getUserLoginDetailsUseCase,
		   LoginPresenter loginPresenter,
		   IGetLoginDetailsUseCase getLoginDetailsUseCase)

		{
			_getUserLoginDetailsUseCase = getUserLoginDetailsUseCase;
			_loginPresenter = loginPresenter;
			_getLoginDetailsUseCase = getLoginDetailsUseCase;
		}
		/// <summary>
		/// Login
		/// </summary>
		[HttpPost("Login")]
		public object Login(LoginAuth login)
		{
			var user = _getUserLoginDetailsUseCase.Execute(login.Email, login.Password);

			if (user.Sucess)
			{
				return new
				{
					status = true,
					code = user.Code,
					message = user.Message
				};
			}
			else
			{
				return new
				{
					status = false,
					code = user.Code,
					message = user.Message
				};
			}

		}
	}
}
