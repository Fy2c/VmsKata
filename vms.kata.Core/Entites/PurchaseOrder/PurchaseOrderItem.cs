using vms.kata.Core.SharedKernel;

namespace vms.kata.Core.Domain.PurchaseOrder
{
    public abstract class PurchaseOrderItem : BaseEntity
    {
        public string ItemNumber { get; set; }
        public string ItemColor { get; set; }
        public string ItemSize { get; set; }
        public string VendorCode { get; set; }

        public string sku { get; set; }
    }
}
