using Cryptolus.Domain.Common.Interfaces;
using Cryptolus.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Application.Common.Interfaces
{
    public interface IGlobalStatisticService<T> where T :  class, IStatistics
    {
        Task<int> GetTotalCountOfPosition();
        Task<int> GetCountOfSuccessPosition();
        Task<int> GetCountOfUnSuccessPosition();
        Task<double> GetSuccessPersentagePosition();
        Task<double> GetUnSuccessPersentagePosition();
    }
}
