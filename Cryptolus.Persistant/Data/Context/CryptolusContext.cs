using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Entities.Post;
using Cryptolus.Domain.Entities.Post.Position;
using Cryptolus.Domain.Entities.Statistic;
using Cryptolus.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Persistant.Data.Context
{
    public class CryptolusContext : DbContext
    {
        public CryptolusContext(DbContextOptions<CryptolusContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Author> Authors => Set<Author>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostThemes>()
                .HasKey(pt => new { pt.PostId,pt.ThemeId });

            modelBuilder.Entity<User>().Property(x => x.Role)
                .HasConversion<string>();

            modelBuilder.Entity<User>().Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Post>().Property(x => x.Type)
                .HasConversion<string>();

            modelBuilder.Entity<PositionInfo>().Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<PositionInfo>().Property(x => x.Direction)
                .HasConversion<string>();

            modelBuilder.Entity<PositionInfo>().Property(x => x.PositionResult)
                .HasConversion<string>();

        }


    }
}
