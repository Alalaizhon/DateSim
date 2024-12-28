using Microsoft.EntityFrameworkCore;

namespace DateSim.Data.Service
{
	public class AppState
	{
		private readonly ILogger<AppState> _logger;
		private readonly ApplicationDbContext _context;

		public AppState(ILogger<AppState> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public Profile? CurrentProfile { get; private set; }

		public event Action? OnChange;

		public async Task SetCurrentProfileAsync(Profile profile)
		{
			CurrentProfile = profile;
			_logger.LogInformation("Профиль установлен: {ProfileName}", profile.Name);

			// Сохраняем текущий профиль в базе данных
			var state = await _context.AppStates.FirstOrDefaultAsync();
			if (state == null)
			{
				state = new AppStateData { CurrentProfileId = profile.Id };
				_context.AppStates.Add(state);
			}
			else
			{
				state.CurrentProfileId = profile.Id;
			}

			await _context.SaveChangesAsync();

			NotifyStateChanged();
		}

		public async Task ClearCurrentProfileAsync()
		{
			CurrentProfile = null;
			_logger.LogInformation("Профиль очищен");

			// Очищаем текущий профиль в базе данных
			var state = await _context.AppStates.FirstOrDefaultAsync();
			if (state != null)
			{
				state.CurrentProfileId = null;
				await _context.SaveChangesAsync();
			}

			NotifyStateChanged();
		}

		public async Task LoadCurrentProfileAsync()
		{
			// Загружаем текущий профиль из базы данных
			var state = await _context.AppStates.FirstOrDefaultAsync();
			if (state != null && state.CurrentProfileId.HasValue)
			{
				CurrentProfile = await _context.Profiles.FindAsync(state.CurrentProfileId.Value);
			}

			NotifyStateChanged();
		}

		private void NotifyStateChanged() => OnChange?.Invoke();
	}

	public class AppStateData
	{
		public int Id { get; set; }
		public int? CurrentProfileId { get; set; }
	}
}