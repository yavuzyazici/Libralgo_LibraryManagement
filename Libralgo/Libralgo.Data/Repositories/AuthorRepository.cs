using Libralgo.Data.Abstract;
using Libralgo.Data.Context;
using Libralgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Data.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorDal
    {
        public AuthorRepository(LibralgoDbContext context) : base(context)
        {
        }
    }
}
