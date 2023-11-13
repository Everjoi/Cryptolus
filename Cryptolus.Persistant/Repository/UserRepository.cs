using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Domain.Entities.User;
using Cryptolus.Persistant.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Persistant.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(CryptolusContext dbContext) : base(dbContext) { }


        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _dbContext.Users.Where(x=>x.Email == email).FirstOrDefaultAsync();
            return result;
        }

    }
}
