using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.ValueObjects;
using Project.Infrastructure.Ef.Config;
using Project.Infrastructure.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Ef.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

			var configuration = new WriteConfiguration();
			modelBuilder.ApplyConfiguration<PackingList>(configuration);
			modelBuilder.ApplyConfiguration<PackingItem>(configuration);

		}
	}
}
