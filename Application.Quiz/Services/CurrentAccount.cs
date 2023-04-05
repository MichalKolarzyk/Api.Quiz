using Application.Quiz.Database;
using Domain.Quiz.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Services
{
    public class CurrentAccount
    {
        private readonly ICurrentIdentity _identity;
        private readonly IRepository<Account> _accountRepository;


        public CurrentAccount(ICurrentIdentity identity, IRepository<Account> accountRepository)
        {
            _identity = identity;
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetCurrentAccount()
        {
            return await _accountRepository.GetAsync(a => a.Id == _identity.AccountId);
        }
    }
}
