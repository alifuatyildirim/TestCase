namespace TestCase.Contract.Abstraction
{
    public interface IQueryEquatable<in T>
    {
        public bool RequestEquals(T query);
    }
}