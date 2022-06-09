using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Domain.MedicalClinic
{
    public sealed class User : IEntity, IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int UnitId { get; set; }
        public int TypeUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public int TotalCount { get; set; }

        public User() { }

        public static User Load(string name, string documentNumber, int unitId, int typeUserId, DateTime createdAt, DateTime updatedAt, bool enabled, string email, int totalCount)
        {
            User user = new User();
            user.Name = name;
            user.DocumentNumber = documentNumber;
            user.UnitId = unitId;
            user.TypeUserId = typeUserId;
            user.CreatedAt = createdAt;
            user.UpdatedAt = updatedAt;
            user.Enabled = enabled;
            user.Email = email;
            user.TotalCount = totalCount;
            return user;
        }
    }
}
