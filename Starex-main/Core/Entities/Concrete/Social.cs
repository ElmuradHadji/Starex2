namespace Core.Entities.Concrete
{
    public class Social: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int SettingId { get; set; }
        public Setting setting { get; set; }
        public bool IsActive  { get; set; }
    }
}
