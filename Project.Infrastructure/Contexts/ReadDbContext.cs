using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Contexts
{
	internal sealed class ReadDbContext : DbContext
	{
		public DbSet<PackingListReadModel> PackingLists { get; set; }

		public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("packing");
			base.OnModelCreating(modelBuilder);
		}
	}
}
