using Core.Entities;

namespace Entities.Concrete
{
    public class PackageStatus : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Package> packages { get; set; }
    }
}
