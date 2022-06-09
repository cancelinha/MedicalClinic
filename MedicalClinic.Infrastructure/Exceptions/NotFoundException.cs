using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Exceptions
{
    internal sealed class NotFoundException : InfrastructureException
    {
        internal NotFoundException(string message)
            : base(message)
        { }
    }
}
