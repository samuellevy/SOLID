using SOLID.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Services
{
    interface IService<D, I>
    {
        List<D> FindAll();
        D FindOne(I id);
        IValue<I> Create(D userDto);
        IValue<I> Update(I id, D userDto);
        void Delete(I id);
    }
}
