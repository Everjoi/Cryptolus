using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Entities.Post;
using Cryptolus.Persistant.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Persistant.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {

        public PostRepository(CryptolusContext dbContext) : base(dbContext) { }

        public async Task<List<Post>> GetPostsByCoin(string coin)
        {
            return await _dbContext.Posts.Where(x => x.Content.Coin == coin || x.Content.CoinSymbol == coin).ToListAsync();
        }

        public async Task<List<Post>> GetPostsByDate(DateTime date)
        {
            return await _dbContext.Posts.Where(x=>x.CreateDate == date).ToListAsync();    
        }

        public async Task<List<Post>> GetPostsByDirection(PositionDirection direction)
        {
            return await _dbContext.Posts.Where(x => x.Position.Direction == direction).ToListAsync();
        }

        public async Task<List<Post>> GetPostsByPeriod(DateTime start,DateTime end)
        {
            return await _dbContext.Posts.Where(x => x.CreateDate > start && x.CreateDate < end).ToListAsync(); 
        }

        public async Task<List<Post>> GetPostsByResult(PositionResult result)
        {
            return await _dbContext.Posts.Where(x=>x.Position.PositionResult == result).ToListAsync();
        }

        public Task<List<Post>> GetPostsByStatus(PositionStatus status)
        {
            return _dbContext.Posts.Where(x => x.Position.Status == status).ToListAsync();  
        }

        public async Task<List<Post>> GetPostsByThemes(List<Themes> themes)
        {
            return await _dbContext.Posts.Where(post => post.PostThemes.Any(x => themes.Contains(x.Theme))).ToListAsync();  
        }

        public async Task<List<Post>> GetPostsBySubscription(Subscription postType)
        {
            return await _dbContext.Posts.Where(x => x.Type == postType).ToListAsync();
        }
    }
}
