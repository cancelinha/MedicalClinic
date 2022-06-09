using MedicalClinic.Application.Dto;
using MedicalClinic.Application.UseCases.User.AddUser;
using MedicalClinic.Application.UseCases.User.GetAllUser;
using MedicalClinic.Application.UseCases.User.UpdateUser;
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
	public class UserController : ControllerBase
	{
		private readonly IAddUserUseCase _addUserUseCase;
		private readonly UserPresenter _userPresenter;
		private readonly IUpdateUserUseCase _updateUserUseCase;
		private readonly IGetAllUserUseCase _getAllUserUseCase;
		public UserController(
			UserPresenter userPresenter,
			IAddUserUseCase addUserUseCase,
			IUpdateUserUseCase updateUserUseCase,
			IGetAllUserUseCase getAllUserUseCase)

		{
			_addUserUseCase = addUserUseCase;
			_userPresenter = userPresenter;
			_updateUserUseCase = updateUserUseCase;
			_getAllUserUseCase = getAllUserUseCase;
		}
		/// <summary>
		/// Add an User
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> Add(UserDto user)

		{
			Result<UserDto> output = await _addUserUseCase.Execute(user);
			_userPresenter.GetPopulateFirst(output);
			return _userPresenter.ContentResult;
		}

		/// <summary>
		/// Alter an User
		/// </summary>
		[HttpPut]
		public async Task<IActionResult> Update(UserDto user)
		{
			Result<UserDto> output = await _updateUserUseCase.Execute(user);
			return Ok(output);
		}

		/// <summary>
		/// Get an User
		/// </summary>

		[HttpPost("GetAllUser")]
		public async Task<IActionResult> All(UserFilterDto filter)
		{
			Result<List<GetAllUserDto>> output = _getAllUserUseCase.Execute(filter);
			_userPresenter.Populate(output);
			return _userPresenter.ContentResult;
		}
	}
}
