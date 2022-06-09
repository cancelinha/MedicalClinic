using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Dto
{
    public class Result<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public int Total { get; set; }
        public int TotalInPage { get; set; }
        public T Data { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeUserId { get; set; }
        public string TypeUser { get; set; }
    }
}
