using Microsoft.EntityFrameworkCore;

namespace dot_net_webapi.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
        
    }
}
