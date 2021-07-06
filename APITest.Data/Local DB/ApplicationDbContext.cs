using APITest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pokémon> Pokémons { get; set; }
        public DbSet<BaseStats> AllBaseStats { get; set; }
        public DbSet<Name> Names { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        }
    }
}
