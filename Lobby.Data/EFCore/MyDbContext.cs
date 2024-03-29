﻿using Lobby.Models.Entities;
using Lobby.Models.Entities.Icon;
using Lobby.Models.Entities.Key;
using Lobby.Models.Entities.Loot;
using Lobby.Models.Entities.Transaction;
using Lobby.Models.Entities.User;
using Lobby.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Lobby.Data.EFCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserIcon>()
            .HasKey(e => new { e.UserId, e.IconId });
    }
    

    public DbSet<User> Users { get; set; }
    
    public DbSet<Icon> Icons { get; set; }
    public DbSet<UserIcon> UsersIcons { get; set; }
    
    public DbSet<Chest> Chests { get; set; }
        
    public DbSet<Key> Keys { get; set; }
        
    public DbSet<ChestLoot> ChestsLoots { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
}