namespace Core.Entities.Concrete
{
    public class Gender:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
