using Dapper;
using PersistenceLayer.Repository.Interfaces;
using PersistenceLayer.Utilities;
using System.Data;

namespace PersistenceLayer.Repository.Implementations
{
    public class Repository<T> : IRepository<T>
    {

        private readonly IDbConnection _dbConnection;

        string tableName = typeof(T).GetCustomAttributes(typeof(TablenameAttribute), false)
                              .Cast<TablenameAttribute>()
                              .FirstOrDefault()?.Name ?? typeof(T).Name; 
        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _dbConnection.Open();
                string query = $"SELECT * FROM {tableName}";
                return _dbConnection.Query<T>(query);
            }
            catch (Exception ex)
            {
                // TODO: log it
                throw new RepositoryException($"Fehler beim Abrufen von Datensaetzen aus {tableName}.", ex);

            }
            finally { _dbConnection.Close(); }

        }

        public T GetByID(int id)
        {
            try
            {

                _dbConnection.Open();
                string query = $"SELECT * FROM {tableName} WHERE Id = @id";
                return _dbConnection.QueryFirstOrDefault<T>(query, new { id });
            }
            catch (Exception ex)
            {

                throw new RepositoryException($"Fehler beim Abrufen von Datensaetzen aus {tableName} mit id {id}.", ex);

            }
            finally { _dbConnection.Close(); }
        }


        public T GetByProperty(string propertyName, object value)
        {
            try
            {
                _dbConnection.Open();

                string query = $"SELECT * FROM {tableName} WHERE {propertyName} = @value";

                return _dbConnection.QueryFirstOrDefault<T>(query, new { value });
            }
            catch (Exception ex)
            {

                throw new RepositoryException($"Fehler beim Abrufen von Datensaetzen aus{tableName} mit propertyName {propertyName}.", ex);

            }
            finally { _dbConnection.Close(); }

        }
    }
}
