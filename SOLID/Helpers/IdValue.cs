using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Helpers
{
    public class IdValue<T> : IValue<T>
    {
        public T Id { get; set; }

        public IdValue(T value)
        {
            Id = value;
        }
    }
}
