using Sparky_Project;
using Xunit;

namespace Sparky
{
    public class CustomerXUnitTest
    {
        private Customer customer;
        public CustomerXUnitTest()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            var fullName = customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
                Assert.Contains("Ben Spark", customer.GreetMessage);
                Assert.StartsWith("Hello, ", customer.GreetMessage);
                Assert.EndsWith("Spark", customer.GreetMessage);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", customer.GreetMessage);
            });


        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNoNull()
        {
            Assert.NotNull(customer.GreetAndCombineNames("Ben", ""));
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Sparky"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 101;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
