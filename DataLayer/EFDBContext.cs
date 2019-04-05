using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBContext : DbContext 
    {
        public DbSet<Directory> Directories { get; set; }
        public DbSet<Material> Materials { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options):base(options) { }

    }
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=loftBlogASPCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
