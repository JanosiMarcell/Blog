using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {

        }
        public BlogDbContext(DbContextOptions option): base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost; database=Blog; user=root; password=";

                optionsBuilder.UseMySQL(conn);
            }
        }
        public DbSet<Blogger> Bloggers { get; set; } = null!;
    }
}
