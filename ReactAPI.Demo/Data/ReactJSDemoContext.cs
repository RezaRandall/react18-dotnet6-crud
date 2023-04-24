using Microsoft.EntityFrameworkCore;
using ReactAPI.Demo.Data.Entities;

namespace ReactAPI.Demo.Data;

public class ReactJSDemoContext:DbContext
{
    public ReactJSDemoContext(DbContextOptions<ReactJSDemoContext> options):base(options)
    {
        
    }
    // register classes as a properties
    public DbSet<Contacts> Contacts{get; set;}
}
