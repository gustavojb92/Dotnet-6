
namespace Dotnet_6.Interfaces
{
    public interface IBase<in T, out A>
    {
        IEnumerable<A> GetAll();

        A GetById(int id);

        A Post(T obj);

        Boolean Delete(int Id);

    }
}