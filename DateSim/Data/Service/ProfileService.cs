using DateSim.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DateSim.Data.Service
{
	public class ProfileService : ProfileInterface
	{
		private readonly ApplicationDbContext _dbContext;

		public ProfileService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Profile>> GetProfilesAsync()
		{
			return await _dbContext.Profiles
				.Include(p => p.Interests) // Загрузка связанных данных
				.ToListAsync();
		}

		public async Task<Profile?> GetProfileByIdAsync(int id)
		{
			return await _dbContext.Profiles
				.Include(p => p.Interests)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<List<Profile>> SearchProfilesByInterestAsync(string interest)
		{
			return await _dbContext.Profiles
				.Include(p => p.Interests)
				.Where(p => p.Interests.Any(i => i.SelectedInterestString.Contains(interest)))
				.ToListAsync();
		}

		public async Task<List<Profile>> FilterProfilesAsync(Func<Profile, bool> filter)
		{
			// Для более сложных фильтров можно использовать LINQ-запросы с загрузкой из базы данных
			var profiles = await _dbContext.Profiles
				.Include(p => p.Interests)
				.ToListAsync();
			return profiles.Where(filter).ToList();
		}

		public async Task AddProfileAsync(Profile profile)
		{
			_dbContext.Profiles.Add(profile);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateProfileAsync(Profile profile)
		{
			_dbContext.Profiles.Update(profile);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteProfileAsync(int id)
		{
			var profile = await _dbContext.Profiles.FindAsync(id);
			if (profile != null)
			{
				_dbContext.Profiles.Remove(profile);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
