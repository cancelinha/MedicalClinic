using MedicalClinic.Application.Dto;
using MedicalClinic.Domain.MedicalClinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Repositories
{
	public interface ILoginRepository
	{
		Task<int> Add(LoginDto login);
		Login Get(string userName, string passWord);
	}
}
