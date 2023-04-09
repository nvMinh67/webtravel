using WebApplication5.EditModel;

namespace WebApplication5.Repositories
{
    public interface IBookingRepository
    {
        public Task<CheckOutEM> createBooking (CheckOutEM checkOutEM);
    }
}
