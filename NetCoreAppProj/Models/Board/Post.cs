using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAppProj.Models.Board
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 128)]
        public string Title { get; set; }

        [StringLength(maximumLength: 128)]
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
