using PersistenceLayer.Model;
using PersistenceLayer.Repository.Interfaces;
using System.Data;

namespace PersistenceLayer.Repository.Implementations
{
    public class SalutationRepository : Repository<Salutations>, ISalutationRepository
    {
        public SalutationRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

    }
}
