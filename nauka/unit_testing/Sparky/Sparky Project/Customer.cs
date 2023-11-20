namespace Sparky_Project
{
    public interface ICustomer
    {
        int OrderTotal { get; set; }
        int Discount { get; set; }
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }

        string GreedAndCombineNames(string firstName, string lastName);
        CustomerType GetCustomerDetails();
    }
    public class Customer : ICustomer
    {
        public int OrderTotal { get; set; }
        public int Discount { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }
        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }

        public string GreedAndCombineNames(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
