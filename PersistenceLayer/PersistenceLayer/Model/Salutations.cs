using PersistenceLayer.Utilities;

namespace PersistenceLayer.Model
{
    [Tablename("Salutation")]
    public class Salutations
    {
        public int Id { get; set; }
        public string Salutation { get; set; }


    }
}
