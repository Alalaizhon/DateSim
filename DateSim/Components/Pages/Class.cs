using System.Collections.Generic;

public class AppState
{
	public List<Profile> LikedProfiles { get; set; } = new List<Profile>();
}

public class Profile
{
	public string Name { get; set; }
	public string Description { get; set; }
	public List<string> Interests { get; set; }
	public string ImageUrl { get; set; }
}
