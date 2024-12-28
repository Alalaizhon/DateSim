using Microsoft.EntityFrameworkCore;
using DateSim.Data;

public class MessageService
{
	private readonly ApplicationDbContext _dbContext;

	public MessageService(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	// Получить сообщения между двумя пользователями
	public async Task<List<Message>> GetMessagesAsync(string senderId, string receiverId)
	{
		return await _dbContext.Messages
			.Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
						(m.SenderId == receiverId && m.ReceiverId == senderId))
			.OrderBy(m => m.SentAt)
			.ToListAsync();
	}

	// Отправить сообщение
	public async Task SendMessageAsync(string senderId, string receiverId, string content)
	{
		var message = new Message
		{
			SenderId = senderId,
			ReceiverId = receiverId,
			Content = content,
			SentAt = DateTime.UtcNow
		};

		_dbContext.Messages.Add(message);
		await _dbContext.SaveChangesAsync();
	}
}