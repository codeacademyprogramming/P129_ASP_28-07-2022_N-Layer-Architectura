using Microsoft.EntityFrameworkCore;
using P129NLayerArchitectura.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Data
{
    public class AppDbContext : DbContext
    {
        //dotnet ef --startup-project ..\P129NLayerArchitectura.Api migrations add AddedCategoriesTable
        //dotnet ef --startup-project ..\P129NLayerArchitectura.Api database update
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
