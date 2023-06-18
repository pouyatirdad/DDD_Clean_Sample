using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project.Infrastructure.Ef.Config;
using Project.Infrastructure.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Ef.Contexts
{
	internal sealed class ReadDbContext : DbContext
    {
        public DbSet<PackingListReadModel> PackingLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

		}
		public class ReadDbContextFactory : IDesignTimeDbContextFactory<ReadDbContext>
		{
			public ReadDbContext CreateDbContext(string[] args)
			{
				var optionsBuilder = new DbContextOptionsBuilder<ReadDbContext>();
				optionsBuilder.UseSqlServer("ConnectionString");

				return new ReadDbContext(optionsBuilder.Options);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration =new ReadConfiguration();
            modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
        }
    }
}
