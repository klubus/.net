using System;

public class Users : Entity
{
    public string Role { get; protected set; }
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    

    public Users()
	{
	}

    protected Users(Guid id, string role, string name, string email, string password)
    {
        Id = id;
        Role = role;
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = DateTime.Now;
    }
}
