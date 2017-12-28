namespace NetCoreAppProj.Models.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 128)]
        public string Username { get; set; }

        [Required]
        [StringLength(maximumLength: 128)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
