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

			// ��������� ����� ����-��-������ ����� Profile � Interests
			builder.Entity<Profile>()
				.HasMany(p => p.Interests) // � Profile ����� ���� ����� Interests
				.WithOne(i => i.Profile) // � Interests ���� ���� Profile
				.HasForeignKey(i => i.ProfileId); // ������� ���� � Interests

			// ��������� �������� SelectedInterestString
			builder.Entity<Interests>()
				.Property(i => i.SelectedInterestString)
				.HasMaxLength(500); // ����������� ����� ������ ���������

			builder.Entity<Profile>().HasData(
				new Profile
				{
					Id = 1,
					Name = "Walter White",
					Age = 34,
					Gender = Gender.�������,
					Description = "����� ���������� ���������� ������.",
					ImageUrl = "Image/Heisenberg.jpg"
				},
				new Profile
				{
					Id = 2,
					Name = "Monica Hall",
					Age = 32,
					Gender = Gender.�������,
					Description = "������� ������������ �� ����� ���������.",
					ImageUrl = "Image/Monica.png"
				},
				new Profile
				{
					Id = 3,
					Name = "Kuromy",
					Age = 19,
					Gender = Gender.�������,
					Description = "����� ���� � ���� ������",
					ImageUrl = "Image/Sit-main.png"
				}
			);

			builder.Entity<Interests>().HasData
				(
				   new Interests { Id = 1, SelectedInterestString = "�����", ProfileId = 1 },
				   new Interests { Id = 2, SelectedInterestString = "������", ProfileId = 3 },
				   new Interests { Id = 3, SelectedInterestString = "�����������", ProfileId = 3 },
				   new Interests { Id = 4, SelectedInterestString = "�����", ProfileId = 1 },
				   new Interests { Id = 5, SelectedInterestString = "����������", ProfileId = 2 }
				);


		}

	}
	
}
