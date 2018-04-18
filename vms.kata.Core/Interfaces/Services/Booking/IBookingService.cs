using vms.kata.Domain.Entites.Booking;

namespace vms.kata.Domain.Interfaces.Services.Booking
{
    public interface IBookingService
    {
        string CreateBookingKey(BookingHeaderInfo bookingHeaderInfo, string module);
    }
}
