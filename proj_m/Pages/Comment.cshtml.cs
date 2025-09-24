using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Models;
using System;
using System.Collections.Generic;

public class CommentModel : PageModel
{
    public List<Comment> Comments { get; private set; }

    public void OnGet()
    {
        Comments = new List<Comment>
        {
            new Comment {
                Id = 1,
                UserName = "Alice",
                Content = "Great post! Thanks for sharing.",
                Likes = 10,
                Dislikes = 1,
                IsPinned = true,
                IsEdited = false,
                IsFlagged = false,
                CommentDate = DateTime.Now.AddDays(-2)
            },
            new Comment {
                Id = 2,
                UserName = "Bob",
                Content = "I disagree with some points, but overall good.",
                Likes = 2,
                Dislikes = 5,
                IsPinned = false,
                IsEdited = true,
                EditedDate = DateTime.Now.AddDays(-1),
                IsFlagged = false,
                CommentDate = DateTime.Now.AddDays(-3)
            },
            new Comment {
                Id = 3,
                UserName = "Charlie",
                Content = "Can you clarify the second paragraph?",
                Likes = 1,
                Dislikes = 0,
                IsPinned = false,
                IsEdited = false,
                IsFlagged = true,
                ModeratorNote = "Review for spam.",
                CommentDate = DateTime.Now.AddDays(-1)
            },
            new Comment {
                Id = 4,
                UserName = "Dana",
                Content = "Replying to Alice: I agree!",
                Likes = 3,
                Dislikes = 0,
                IsPinned = false,
                IsEdited = false,
                IsFlagged = false,
                ReplyToUser = "Alice",
                CommentDate = DateTime.Now
            }
        };
    }
}
