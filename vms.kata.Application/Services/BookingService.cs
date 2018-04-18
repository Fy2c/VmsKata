using vms.kata.Domain.Entites.Booking;
using vms.kata.Domain.Interfaces.Services.Booking;
using vms.kata.Domain.Interfaces.Services.Config;
using vms.kata.Domain.Interfaces.Services.User;

namespace vms.kata.Application.Services
{
    public class BookingService : IBookingService
    {
        #region Construtor, Property
        private IMppService mppService;
        private IPepService pepService;
        private IUserService userService;
        private IConfigService configService;

        public BookingService(IMppService mppService, IPepService pepService, IUserService userService, IConfigService configService)
        {
            this.mppService = mppService;
            this.pepService = pepService;
            this.userService = userService;
            this.configService = configService;
        }
        #endregion

        #region Public Method
        public string CreateBookingKey(BookingHeaderInfo bookingHeaderInfo, string module)
        {
            return CreateBookingKey(bookingHeaderInfo, module, null);
        }

        public string CreateBookingKey(BookingHeaderInfo bookingHeaderInfo, string module, string userId)
        {
            BookingHeaderInfo localBookingHeaderInfo = new BookingHeaderInfo()
            {
                CompanyCode = bookingHeaderInfo.CompanyCode,
                WorkId = bookingHeaderInfo.WorkId,
                Destination = bookingHeaderInfo.Destination,
                Subgroup = bookingHeaderInfo.Subgroup
            };

            OverrideCompanyByWorkId(bookingHeaderInfo, module, localBookingHeaderInfo);
            HasDefaultCompanyWorkId(bookingHeaderInfo, localBookingHeaderInfo);
            OverrideByUserWorkId(userId, localBookingHeaderInfo);

            string runningSeq = configService.GetDbConfig("LAST_BOOKING_KEY" + localBookingHeaderInfo.Subgroup + localBookingHeaderInfo.WorkId, 1, 6, true);
            HasVobCarrierRelease(bookingHeaderInfo, localBookingHeaderInfo);

            return (localBookingHeaderInfo.Subgroup.Trim() + localBookingHeaderInfo.Destination.Trim() + runningSeq.ToString().Trim() + localBookingHeaderInfo.WorkId.Trim()).ToUpper();
        }

        #endregion

        #region Private Method
        private void HasVobCarrierRelease(BookingHeaderInfo bookingHeaderInfo, BookingHeaderInfo localBookingHeaderInfo)
        {
            if (mppService.PropertyFoundForCompany("book", "VOBCarrierRelease", "Hidden", bookingHeaderInfo.CompanyCode))
                localBookingHeaderInfo.Destination = localBookingHeaderInfo.CompanyCode;
        }

        private void HasDefaultCompanyWorkId(BookingHeaderInfo bookingHeaderInfo, BookingHeaderInfo localBookingHeaderInfo)
        {
            if (mppService.PropertyFoundForCompany("book", "BookingKeyGlossaryDefaultWorkID", "term", bookingHeaderInfo.CompanyCode))
                localBookingHeaderInfo.WorkId = mppService.GetPropertyForCompany("book", "BookingKeyGlossaryDefaultWorkID", "term", bookingHeaderInfo.CompanyCode);
        }

        private static void OverrideCompanyByWorkId(BookingHeaderInfo bookingHeaderInfo, string module, BookingHeaderInfo localBookingHeaderInfo)
        {
            switch (bookingHeaderInfo.CompanyCode)
            {
                case "862":
                    localBookingHeaderInfo.WorkId = "ISF";
                    break;
                case "778":
                    if (module == "VOB") localBookingHeaderInfo.WorkId = "ISF";
                    break;
            }   
        }

        private void OverrideByUserWorkId(string userId, BookingHeaderInfo localBookingHeaderInfo)
        {
            if (!string.IsNullOrWhiteSpace(userId) && pepService.PropertyFoundForUser("BookingManagementTab.aspx", "OriginCreateBooking", "UseOfficeCode", userId))
                localBookingHeaderInfo.WorkId = userService.GetWorkId(userId);
        }
        #endregion
    }
}
