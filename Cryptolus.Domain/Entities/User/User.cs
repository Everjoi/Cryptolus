using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Common.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Domain.Entities.User
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Member;
        public string Photo { get; set; } = string.Empty;

        public Subscription Status { get; set; } = Subscription.Base;
        public bool IsAuthenticated { get; set; } = false;

    }


}
