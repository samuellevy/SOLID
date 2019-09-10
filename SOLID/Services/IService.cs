using SOLID.ObjectValues.IdValue;
using System.Collections.Generic;

namespace SOLID.Service
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
