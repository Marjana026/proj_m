using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using proj_m.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncSyntax.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [MaxLength(100, ErrorMessage = "User name cannot exceed 100 characters.")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [ValidateNever]
        public DateTime CommentDate { get; set; } = DateTime.Now;

        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }

        [ValidateNever]
        public Post Post { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool IsFlagged { get; set; }

        // New features
        public bool IsEdited { get; set; } // Track if comment was edited
        public DateTime? EditedDate { get; set; } // When comment was edited
        public string? ReplyToUser { get; set; } // Reply to another user
        public bool IsPinned { get; set; } // Pin important comments
        public string? ModeratorNote { get; set; } // Note for moderation

        public string GetSummary()
        {
            return Content?.Length > 50 ? Content.Substring(0, 50) + "..." : Content;
        }

        public void Edit(string newContent)
        {
            Content = newContent;
            IsEdited = true;
            EditedDate = DateTime.Now;
        }
    }
}