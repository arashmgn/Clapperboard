using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain.Common
{
    public abstract class Entity
    {
    public Guid Id { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is not EntityHandle other || other.GetType() != GetType())
        {
            return false;
        }
    }
        public override int GetHashCode() => Id == Geuid.Empty ? base.GetHashCode() : HashCode.Combine(GetType(), Id);
    }

}
