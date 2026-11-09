using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain.Common
{
    public class DomainException(string message) : Exception(message);

    public class ForbiddenDomainException(string message) : DomainException(message);


}
