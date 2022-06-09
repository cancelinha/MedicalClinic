using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application
{
    public class ApplicationModuleException : Exception
    {
        public ApplicationModuleException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
