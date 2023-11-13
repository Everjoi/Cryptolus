using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Domain.Entities.Statistic
{
    public class GeneralStatistic :  IStatistics
    {
        public Guid Id { get; set; }
        public int TotalCount { get; set; }
        public int CountOfSuccess { get; set; }
        public int CountOfUnSuccess { get; set; }
        public double PercentOfSuccess { get; set; }
        public double PercentOfUnSuccess { get; set; }
        public double PercentOfProfitability { get; set; }
        public Subscription Status { get; set; }
    }
}
