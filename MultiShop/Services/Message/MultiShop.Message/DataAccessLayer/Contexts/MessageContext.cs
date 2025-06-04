using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccessLayer.Entities;

namespace MultiShop.Message.DataAccessLayer.Contexts
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
