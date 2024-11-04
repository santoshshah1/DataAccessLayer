using System.Data;
using Microsoft.Extensions.DependencyInjection;
using PersistenceLayer.Repository.Implementations;
using PersistenceLayer.Repository.Interfaces;

namespace PersistenceLayer.Configurations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegistriereStammDatenPersistenz(IServiceCollection serviceCollections, IDbConnection dbConnection)
        {
            serviceCollections.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollections.AddScoped<ISalutationRepository, SalutationRepository>();
            serviceCollections.AddScoped<IDbConnection>(db => dbConnection);
            
            return serviceCollections;
        }
    }
}
