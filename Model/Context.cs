using Microsoft.EntityFrameworkCore;

namespace Checkpoint3
{
    public class Context : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server = AG\SQLEXPRESS;Database = CheckPoint3; Integrated Security=True");
        }
    }
}