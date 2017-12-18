namespace NetCoreAppProj.Models.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public Guid UserId { get; }

        [Required]
        public string Username { get; }

        [Required]
        public string Email { get; }

        [Required]
        public string Password { get; }
    }
}
