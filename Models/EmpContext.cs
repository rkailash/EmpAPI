using Microsoft.EntityFrameworkCore;

namespace EmpApi.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> EmpCollection { get; set; }
    }
}