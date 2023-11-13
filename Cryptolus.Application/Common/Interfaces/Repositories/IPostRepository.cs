using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Application.Common.Interfaces.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPostsByCoin(string coin);
        Task<List<Post>> GetPostsByResult(PositionResult result);
        Task<List<Post>> GetPostsByDirection(PositionDirection direction);
        Task<List<Post>> GetPostsByStatus(PositionStatus status);
        Task<List<Post>> GetPostsByThemes(List<Themes> themes);
        Task<List<Post>> GetPostsByDate(DateTime date);
        Task<List<Post>> GetPostsByPeriod(DateTime start, DateTime end);
        Task<List<Post>> GetPostsBySubscription(Subscription postType);
    }
     
}
