using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MultiShopCommentDatabase;User=sa;Password=123456aA+;trustservercertificate=true;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
