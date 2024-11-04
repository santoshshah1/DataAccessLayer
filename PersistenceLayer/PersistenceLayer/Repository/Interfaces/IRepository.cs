namespace PersistenceLayer.Repository.Interfaces
{
    public interface IRepository<T>
    {
        //extend as required
        IEnumerable<T> GetAll();
        T GetByID(int id);
        T GetByProperty(string propertyName, object value);
    }
}