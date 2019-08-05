using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Mappers
{
    public interface IMapper<E, D>
    {
        D ToDto(E entity);
        E ToEntity(D dto);
    }
}
