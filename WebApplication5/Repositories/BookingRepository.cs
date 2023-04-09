using WebApplication5.EditModel;
using WebApplication5.Entity;

namespace WebApplication5.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MyDbContext _context;

        public BookingRepository(MyDbContext context) {
            _context = context;
        }
        public async Task<CheckOutEM> createBooking(CheckOutEM model)
        {
            var booking = new Booking()
            {
                Email = model.Email,
                Payment = model.Payment,
                Phone = model.Phone,
                Address = model.Address,
                Name = model.Name,
                Note = model.Note,
            };
            _context.booking.Add(booking);  
            await _context.SaveChangesAsync();

            var tour = await _context.tours.FindAsync(model.id_tour);
            var detail_booking = new Booking_Detail()
            {
                id_booking = booking.Id,
                id_tour = model.id_tour,
                Tour = tour,
                amount_ticket = model.amount_ticket,
                total_price = model.total_price,
                Status = Status.pending,
                booking = booking,

            };
            _context.booking_Details.Add(detail_booking);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
