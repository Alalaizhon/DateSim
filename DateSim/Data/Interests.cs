namespace DateSim.Data
{
	public class Interests
	{
		public int Id { get; set; } // Уникальный идентификатор интереса
		public string? SelectedInterestString { get; set; } // Строка с интересами

		// Внешний ключ для связи с Profile
		public int ProfileId { get; set; }

		// Навигационное свойство для связи с Profile
		public Profile? Profile { get; set; }
	}
}
