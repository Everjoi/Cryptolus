using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Domain.Common.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
