using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        private AppContext _context;
        public AccountDAL()
        {
            _context = new AppContext();
        }
        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
