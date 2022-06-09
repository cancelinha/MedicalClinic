using MedicalClinic.Application.Dto;
using MedicalClinic.WebApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MedicalClinic.WebApi.Presenters
{
    public class UserPresenter
    {
        public JsonContentResult ContentResult { get; }

        public UserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void PopulateFirst(UserDto dto)
        {
            if (dto == null)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }

        public void GetPopulateFirst(Result<UserDto> dto)
        {
            if (dto == null)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.NoContent);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }
        public void Populate(Result<List<UserDto>> dto)
        {
            if (dto.Data == null)
            {
                //ContentResult.StatusCode = (int)(HttpStatusCode.NotFound);
                ContentResult.Content = JsonSerializer.SerializeObject(dto);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }

        public void Populate(Result<List<GetAllUserDto>> dto)
        {
            if (dto.Data == null)
            {
                //ContentResult.StatusCode = (int)(HttpStatusCode.NotFound);
                ContentResult.Content = JsonSerializer.SerializeObject(dto);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }
        public void Populate(Result<UserDto> dto)
        {
            if (dto.Sucess == false)
            {
                ContentResult.StatusCode = (int)(HttpStatusCode.BadRequest);
                ContentResult.Content = JsonSerializer.SerializeObject(dto);
                return;
            }

            ContentResult.StatusCode = (int)(HttpStatusCode.OK);
            ContentResult.Content = JsonSerializer.SerializeObject(dto);
        }
    }
}
