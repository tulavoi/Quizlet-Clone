﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("Flashcards")]
    public class Flashcard
    {
        public int Id { get; set; }
        public string? ImageFileName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Term { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Definition { get; set; } = string.Empty;
        public bool IsMark { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
		public int CourseId { get; set; }
        public Course? Course { get; set; }

        [Required]
        public int Term_LangId { get; set; }
        public Language? Term_Lang { get; set; }

        [Required]
        public int Definition_LangId { get; set; }
        public Language? Definition_Lang { get; set; }
    }
}
