namespace NetCoreAppProj.Models.Board
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 128)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 128)]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
