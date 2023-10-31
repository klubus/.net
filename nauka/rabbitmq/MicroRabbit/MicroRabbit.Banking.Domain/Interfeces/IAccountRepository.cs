using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Domain.Interfeces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
