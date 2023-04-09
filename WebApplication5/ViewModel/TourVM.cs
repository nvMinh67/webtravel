using WebApplication5.Entity;

namespace WebApplication5.ViewModel
{
    public class TourVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int num_day { get; set; }

        public int Amount { get; set; }

        public List<Location> diadiem { get; set; }
    }
}
