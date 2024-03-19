using Microsoft.EntityFrameworkCore;
using Rede.Social.Server.Repository;

namespace Rede.Social.Server.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> Users {get; set;}
    public virtual DbSet<Profile> Profiles {get;set;}
    
}
