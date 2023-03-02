using Core.Entities;

namespace Entities.Concrete
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string ShortName { get; set; }
        public List<Country> Country { get; set; }
    }
}
