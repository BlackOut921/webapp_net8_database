using Microsoft.EntityFrameworkCore;

using webapp_net8_database.Models;

namespace webapp_net8_database.Data
{
	public class MyDbContext : DbContext
	{
		public DbSet<MyDbModel> MyDbModels { get; set; }

		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Seed
			MyDbModel master = new MyDbModel { Id = -1, Name = "921", TimeStamp = DateTime.Now };
			modelBuilder.Entity<MyDbModel>().HasData(master);
		}
	}
}
