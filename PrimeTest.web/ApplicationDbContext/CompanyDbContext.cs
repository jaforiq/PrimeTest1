using PrimeTechTest.Models;
using Microsoft.EntityFrameworkCore;

namespace PrimeTechTest.ApplicationDbContext;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<ColumnMetaData> ColumnMetaDatas { get; set; }
    public DbSet<ColumnValue> ColumnValues { get; set; }
    
}
