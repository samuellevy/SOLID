namespace SOLID.ObjectValues.IdValue
{
    public class IdValue<T> : IValue<T>
    {
        public IdValue(T id)
        {
            Id = id;
        }
    }
}
