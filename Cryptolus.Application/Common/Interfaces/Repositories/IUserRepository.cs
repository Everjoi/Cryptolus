using Cryptolus.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
