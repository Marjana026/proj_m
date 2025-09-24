using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Models;
using System;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    public List<Post> LatestPosts { get; private set; }
    public List<dynamic> RecentReviews { get; private set; }
    public List<Comment> TopComments { get; private set; }

    public void OnGet()
    {
        LatestPosts = new List<Post>
        {
            new Post { Title = "Welcome to SyncSyntax", Author = "Admin", PublishedDate = DateTime.Now.AddDays(-1), Summary = "Get started with our contact management system." },
            new Post { Title = "How to Use Categories", Author = "Alice", PublishedDate = DateTime.Now.AddDays(-2), Summary = "Organize your contacts with categories." },
            new Post { Title = "Review Feature Overview", Author = "Bob", PublishedDate = DateTime.Now.AddDays(-3), Summary = "Learn about our review and rating system." }
        };

        RecentReviews = new List<dynamic>
        {
            new { ReviewerName = "User 1", Rating = 5, Comment = "Excellent app!" },
            new { ReviewerName = "User 2", Rating = 4, Comment = "Very useful and easy to use." },
            new { ReviewerName = "User 3", Rating = 3, Comment = "Good, but could use more features." }
        };

        TopComments = new List<Comment>
        {
            new Comment { UserName = "Alice", Content = "Great post!", CommentDate = DateTime.Now.AddDays(-1), IsPinned = true },
            new Comment { UserName = "Bob", Content = "Thanks for the info.", CommentDate = DateTime.Now.AddDays(-2), IsPinned = false },
            new Comment { UserName = "Charlie", Content = "Looking forward to more updates.", CommentDate = DateTime.Now.AddDays(-3), IsPinned = false }
        };
    }
}
