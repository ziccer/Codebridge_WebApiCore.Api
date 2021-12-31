using Codebridge_WebApiCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codebridge_WebApiCore.Data.Context
{
    public class CodebridgeContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public CodebridgeContext(DbContextOptions<CodebridgeContext> options) : base(options) 
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(new Dog { Name = "Neo", Color = "red & amber", Tail_Length = 22, Weight = 32 });
            modelBuilder.Entity<Dog>().HasData(new Dog { Name = "Jessy", Color = "black & white", Tail_Length = 7, Weight = 14 });
        }
    }
}
