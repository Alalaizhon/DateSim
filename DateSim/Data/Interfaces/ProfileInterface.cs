namespace DateSim.Data.Interfaces
{
	public interface ProfileInterface
	{
		Task<List<Profile>> GetProfilesAsync(); // Получить все профили
		Task<Profile?> GetProfileByIdAsync(int id); // Получить профиль по ID
		Task<List<Profile>> SearchProfilesByInterestAsync(string interest); // Поиск профилей по интересу
		Task<List<Profile>> FilterProfilesAsync(Func<Profile, bool> filter); // Фильтрация профилей по заданному условию
		Task AddProfileAsync(Profile profile); // Добавить новый профиль
		Task UpdateProfileAsync(Profile profile); // Обновить профиль
		Task DeleteProfileAsync(int id); // Удалить профиль
	}	
}
