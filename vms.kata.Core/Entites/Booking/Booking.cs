using System.Collections.Generic;

namespace vms.kata.Domain.Entites.Booking
{
    public class Booking
    {
        public string BookingKey { get; set; }
        public BookingHeaderInfo BookingHeaderInfo { get; set; }
        public ICollection<BookingItem> BookingItems { get; set; }
    }
}
