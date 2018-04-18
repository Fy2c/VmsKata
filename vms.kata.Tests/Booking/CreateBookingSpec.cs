using Microsoft.VisualStudio.TestTools.UnitTesting;
using vms.kata.Domain.Entites.Booking;

namespace vms.kata.Tests.BookingSpec
{
    [TestClass]
    public class CreateBookingSpec : CreateBookingSpecSetup
    {
        [TestMethod]
        public void CreateVobBookingKey()
        {

            string bookinKey = bookingService.CreateBookingKey(
                new BookingHeaderInfo
                {
                    Subgroup = "PAS",
                    Destination = "VAN",
                    WorkId = "SH0",
                    CompanyCode = "778"
                }, "VOB");

            Assert.AreEqual("PASVANG00001ISF", bookinKey);
        }

        [TestMethod]
        public void CreateVobBookingKeyWithMpp()
        {
            string bookinKey = bookingService.CreateBookingKey(
                new BookingHeaderInfo
                {
                    Subgroup = "PAS",
                    Destination = "VAN",
                    WorkId = "SH0",
                    CompanyCode = "957"
                }, "VOB");

            Assert.AreEqual("PAS957G00001DDP", bookinKey);
        }

        [TestMethod]
        public void CreateVobBookingKeyWithUser()
        {
            string bookinKey = bookingService.CreateBookingKey(
                new BookingHeaderInfo
                {
                    Subgroup = "PAS",
                    Destination = "VAN",
                    WorkId = "SH0",
                    CompanyCode = "778"
                }, "VOB", "JohnDoe");

            Assert.AreEqual("PASVANG00001HK0", bookinKey);
        }

        [TestMethod]
        public void CreateObmBookingKey()
        {
            string bookinKey = bookingService.CreateBookingKey(
                new BookingHeaderInfo
                {
                    Subgroup = "PAS",
                    Destination = "VAN",
                    WorkId = "SH0",
                    CompanyCode = "778"
                }, "OBM");

            Assert.AreEqual("PASVANG00001SH0", bookinKey);
        }
    }
}