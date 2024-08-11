using Microsoft.EntityFrameworkCore;

namespace CRUD_DEMO.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions option) : base(option)
        {
            
        }
        public DbSet <Employee> Employees { get; set;}
        
    }
}
