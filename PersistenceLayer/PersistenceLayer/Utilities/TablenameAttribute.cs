namespace PersistenceLayer.Utilities
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TablenameAttribute : Attribute
    {
        public string Name { get; }

        public TablenameAttribute(string name)
        {
            Name = name;
        }
    }
}