namespace NetCoreAppProj.Models.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User(Guid userId, string username, string email, string password)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Password = password;
        }

        public Guid UserId { get; }

        [Required]
        public string Username { get; }

        [Required]
        public string Email { get; }

        [Required]
        public string Password { get; }
    }
}
