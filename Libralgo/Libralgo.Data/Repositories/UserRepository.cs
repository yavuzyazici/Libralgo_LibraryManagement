using Libralgo.Data.Abstract;
using Libralgo.Data.Context;
using Libralgo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserDal
    {
        private readonly LibralgoDbContext _context;
        public UserRepository(LibralgoDbContext context) : base(context)
        {
            _context = context;
        }

        public User? GetByMail(string email)
        {
            return _context.Users
                           .FirstOrDefault(u => u.MailAddress.ToLower() == email.ToLower());
        }
    }
}
