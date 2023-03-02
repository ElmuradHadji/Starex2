namespace Core.Entities.Concrete
{
    public class Setting: IEntity
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Logo { get; set; }
        public List<Social> socials { get; set; }
    }
}
