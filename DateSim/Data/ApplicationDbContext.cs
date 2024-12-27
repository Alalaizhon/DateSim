using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static DateSim.Data.Interests;

namespace DateSim.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Profile> Profiles { get; set; }
		public DbSet<Interests> Interests { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Настройка связи один-ко-многим между Profile и Interests
			builder.Entity<Profile>()
				.HasMany(p => p.Interests) // У Profile может быть много Interests
				.WithOne(i => i.Profile) // У Interests есть один Profile
				.HasForeignKey(i => i.ProfileId); // Внешний ключ в Interests

			// Настройка свойства SelectedInterestString
			builder.Entity<Interests>()
				.Property(i => i.SelectedInterestString)
				.HasMaxLength(500); // Ограничение длины строки интересов

			builder.Entity<Profile>().HasData(
				new Profile
				{
					Id = 1,
					Name = "Walter White",
					Age = 34,
					Gender = Gender.Мужчина,
					Description = "Люблю жесточайше заниматься химией.",
					ImageUrl = "Image/Heisenberg.jpg"
				},
				new Profile
				{
					Id = 2,
					Name = "Monica Hall",
					Age = 32,
					Gender = Gender.Женщина,
					Description = "Длинные программисты из Пегий дудочника.",
					ImageUrl = "Image/Monica.png"
				},
				new Profile
				{
					Id = 3,
					Name = "Kuromy",
					Age = 19,
					Gender = Gender.Женщина,
					Description = "черни цвет и мили личико",
					ImageUrl = "Image/Sit-main.png"
				}
			);

			builder.Entity<Interests>().HasData
				(
				   new Interests { Id = 1, SelectedInterestString = "Спорт", ProfileId = 1 },
				   new Interests { Id = 2, SelectedInterestString = "Музыка", ProfileId = 3 },
				   new Interests { Id = 3, SelectedInterestString = "Путешествия", ProfileId = 3 },
				   new Interests { Id = 4, SelectedInterestString = "Наука", ProfileId = 1 },
				   new Interests { Id = 5, SelectedInterestString = "Технологии", ProfileId = 2 }
				);


		}

	}
	
}
