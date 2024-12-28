namespace DateSim.Data
{
	public class Message
	{
		public int Id { get; set; } // Уникальный идентификатор сообщения
		public string SenderId { get; set; } // ID отправителя
		public string ReceiverId { get; set; } // ID получателя
		public string Content { get; set; } // Текст сообщения
		public DateTime SentAt { get; set; } // Время отправки сообщения

		// Навигационные свойства для связи с пользователями
		public ApplicationUser Sender { get; set; }
		public ApplicationUser Receiver { get; set; }
	}
}
