namespace Core.Entities.DTOs.SocialDTOs
{
    public class SocialPostDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int SettingId { get; set; }
        public bool IsActive { get; set; }
    }
}
