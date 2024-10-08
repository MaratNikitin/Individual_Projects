﻿using System;
using System.Collections.Generic;
using EfCore.Data.ScaffoldModels;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data.ScaffoldContext;

public partial class FootballLeagueEfCoreContext : DbContext
{
    public FootballLeagueEfCoreContext()
    {
    }

    public FootballLeagueEfCoreContext(DbContextOptions<FootballLeagueEfCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballLeague_EfCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
