using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.UseCases.Login.GetLoginDetails
{
    public interface IGetLoginDetailsUseCase
    {
        LoginDto Execute(string user, string senha);
    }
}
