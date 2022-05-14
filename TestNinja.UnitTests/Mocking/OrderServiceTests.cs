using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mock
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_ShouldPlaceTheOrder()
        {
            var storage = new Mock<IStorage>();
            var orderService = new OrderService(storage.Object);

            var order = new Order();
            orderService.PlaceOrder(order);

            storage.Verify(s => s.Store(order));
        }
    }
}
