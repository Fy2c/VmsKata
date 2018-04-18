using vms.kata.Core.Domain.PurchaseOrder;
using vms.kata.Core.SharedKernel;

namespace vms.kata.Domain.Entites.Booking
{
    public abstract class BookingItem : BaseEntity
    {
        public string BookingKey { get; set; }
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; }
       
    }
}
