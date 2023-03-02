using Entities.Concrete;

namespace Final.VMs
{
    public class HomeVM
    {
        public List<About> About { get; set; }
        public List<Advantage> Advantage { get; set; }
        public List<FAQ> FAQ { get; set; }
        public List<FAQCategory> FAQCategoriy { get; set; }
        public List<News> News { get; set; }
        public List<Pricing> Pricing { get; set; }
    }
}
