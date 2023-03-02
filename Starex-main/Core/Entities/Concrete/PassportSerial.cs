namespace Core.Entities.Concrete
{
    public class PassportSerial:IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
