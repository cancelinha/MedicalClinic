using MedicalClinic.Application.Dto;
using MedicalClinic.Application.UseCases.Login.AddLogin;
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
    public class LoginController : ControllerBase
    {
        private readonly IAddLoginUseCase _addLoginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public LoginController(

            LoginPresenter loginPresenter,
            IAddLoginUseCase addLoginUseCase)
        {
            _addLoginUseCase = addLoginUseCase;
            _loginPresenter = loginPresenter;
        }
        [HttpPost]
        public async Task<IActionResult> Add(LoginDto login)
        {
            Result<LoginDto> output = await _addLoginUseCase.Execute(login);
            _loginPresenter.Populate(output);
            return _loginPresenter.ContentResult;
        }
    }
}
