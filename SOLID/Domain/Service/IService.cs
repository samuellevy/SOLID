using SOLID.Domain.IdValue;
using System.Collections.Generic;

namespace SOLID.Domain.Service
{
    public interface IService<D, I> 
    {
        List<D> FindAll();
        D FindOne(I id);
        IValue<I> Create(D user);
        IValue<I> Update(I id, D user);
        bool Delete(I id);
    }
}
