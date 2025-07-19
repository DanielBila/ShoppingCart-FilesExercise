using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Entities.Exceptions
{
    internal class DomainExceptionEntities : ApplicationException
    {
        public DomainExceptionEntities(string message) 
        :base(message)
        { 
        }
    }
}
