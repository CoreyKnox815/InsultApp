using Microsoft.EntityFrameworkCore;
using Insulter.Models;


namespace Insulter.Data
{

    public class InsultContext : DbContext
    {
        public InsultContext(DbContextOptions<InsultContext> options) : base(options) { }
        public DbSet<Insult> insults { get; set; }
    }
}