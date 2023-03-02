using Core.Entities;

namespace Entities.Concrete
{
    public class About: IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
    }
}
