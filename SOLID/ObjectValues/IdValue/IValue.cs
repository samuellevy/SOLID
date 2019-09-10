using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.ObjectValues.IdValue
{
    public abstract class IValue<T>
    {
        public T Id { get; set; }
    }
}
