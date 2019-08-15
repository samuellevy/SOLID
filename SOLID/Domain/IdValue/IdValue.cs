using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Domain.IdValue
{
    public class IdValue<T> : IValue<T>
    {
        public IdValue(T id)
        {
            Id = id;
        }
    }
}
