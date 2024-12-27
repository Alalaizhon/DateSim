using DateSim.Data;
using System.Collections.Generic;

public class AppState
{
	public List<Profile> LikedProfiles { get; set; } = new List<Profile>();
}

public enum Gender
{
	Мужчина,
	Женщина,
}

public class Profile
{
	public int Id { get; set; } // Уникальный идентификатор профиля
    public string? Name { get; set; } // Имя профиля
    public int? Age { get; set; } // Возраст
    public Gender Gender { get; set; } // Пол
    public string? Description { get; set; } // Описание
    public string? ImageUrl { get; set; } // Ссылка на изображение

    // Навигационное свойство для связи с Interests
    public ICollection<Interests> Interests { get; set; } = new List<Interests>();
}