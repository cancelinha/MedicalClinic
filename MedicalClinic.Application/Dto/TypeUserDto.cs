using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Dto
{
    public sealed class TypeUserDto
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TypeUserDto() { }

        public static TypeUserDto Load(int id, int name, DateTime createdAt, DateTime updatedAt)
        {
            TypeUserDto typeUser = new TypeUserDto();
            typeUser.Id = id;
            typeUser.Name = name;
            typeUser.CreatedAt = createdAt;
            typeUser.UpdatedAt = updatedAt;

            return typeUser;
        }
    }
}
