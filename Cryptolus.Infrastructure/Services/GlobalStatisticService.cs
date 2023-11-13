using Cryptolus.Application.Common.Interfaces;
using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Infrastructure.Services
{
    public class GlobalStatisticService<T>:IGlobalStatisticService<T> where T : class, IStatistics
    {
        private readonly Subscription _postType;
        private readonly IPostRepository _postRepository;

        public GlobalStatisticService(Subscription postType, IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _postType = postType;
        }

        public async Task<int> GetCountOfSuccessPosition()
        {
            var successPost = await _postRepository.GetPostsByResult(PositionResult.Proffit);
            var postByType = successPost.Where(x => x.Type == _postType);
            return postByType.Count();
        }

        public async Task<int> GetCountOfUnSuccessPosition()
        {
            var successPost = await _postRepository.GetPostsByResult(PositionResult.Lose);
            var postByType = successPost.Where(x => x.Type == _postType);
            return postByType.Count();
        }

        public async Task<double> GetSuccessPersentagePosition()
        {
            var totalPosition = await GetTotalCountOfPosition();
            var successPosition = await  GetCountOfSuccessPosition();
            var result = (double) (100 * successPosition / totalPosition);
            return result;
        }

        public async Task<int> GetTotalCountOfPosition()
        {
            var position = await _postRepository.GetPostsByStatus(PositionStatus.Closed);
            var positionByType = position.Where(x => x.Type == _postType);
            return positionByType.Count();       
        }

         

        public async Task<double> GetUnSuccessPersentagePosition()
        {
            var totalPosition = await GetTotalCountOfPosition();
            var UnSuccessPosition = await GetCountOfUnSuccessPosition();
            var result = (double)(100 * UnSuccessPosition / totalPosition);
            return result;
        }
    }
}
