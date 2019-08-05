using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Mappers
{
    public interface IMapper<T, F>
    {

        F From(T to);
        T To(F from);
    }
}
