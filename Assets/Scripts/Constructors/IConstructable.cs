namespace Constructors
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IConstructable<T>
    {
        void Construct(T value);
    }
}