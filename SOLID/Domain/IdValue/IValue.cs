using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Domain.IdValue
{
    public abstract class IValue<T>
    {
        public T Id { get; set; }
    }
}
