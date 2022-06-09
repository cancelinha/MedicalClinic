using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Dto
{
    public sealed class UserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TypeUserId { get; set; }
        public string TypeUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public int TotalCount { get; set; }
        public LoginDto Login { get; set; }
        public UserDto() { }

        public static UserDto Load(string name, string documentNumber, string unit, int unitId, int outpost, string zipCode, string typeUser, int typeUserId, DateTime createdAt, DateTime updatedAt, bool enabled, string email, int clientId, int paymentConditionId, int paymentDeadlineId, int totalCount)
        {
            UserDto user = new UserDto();
            user.Name = name;
            user.TypeUser = typeUser;
            user.TypeUserId = typeUserId;
            user.CreatedAt = createdAt;
            user.UpdatedAt = updatedAt;
            user.Enabled = enabled;
            user.Email = email;
            user.TotalCount = totalCount;
            return user;
        }
    }
    public sealed class GetAllUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TypeUser { get; set; }
        public int TotalCount { get; set; }


        public GetAllUserDto() { }

        public static GetAllUserDto Load(string name, string typeUser, string unit, string email, int totalCount)
        {
            GetAllUserDto user = new GetAllUserDto();

            user.Name = name;
            user.TypeUser = typeUser;
            user.TotalCount = totalCount;
            user.Email = email;
            return user;
        }
    }
    public sealed class UserFilterDto
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public string Search { get; set; }

        public UserFilterDto() { }

        public UserFilterDto(int pageNumber, int rowsPerPage, string search)
        {
            UserFilterDto sellerFilter = new UserFilterDto();

            sellerFilter.PageNumber = pageNumber;
            sellerFilter.RowsPerPage = rowsPerPage;
            sellerFilter.Search = search;
        }
    }
}
