using Lobby.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Lobby.Data.EFCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}