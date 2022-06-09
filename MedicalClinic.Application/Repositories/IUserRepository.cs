using MedicalClinic.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Repositories
{
	public interface IUserRepository
	{
        UserDto GetByLogin(string email, string password);
        UserDto GetByUserEmail(string email);
        LoginDto GetByUser(string email);
        UserDto GetTypeUser(int UserId);
        UserDto GetTypeUserByName(string UserName);
        List<GetAllUserDto> GetAll(UserFilterDto filter);
        Task<int> Add(UserDto user);
        Task<int> Update(UserDto user);
    }
}
