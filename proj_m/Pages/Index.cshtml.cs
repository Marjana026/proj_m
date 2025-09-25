using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SyncSyntax.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class IndexModel : PageModel
{
    [BindProperty]
    public string UserName { get; set; }
    [BindProperty]
    public string Content { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
    private static List<Comment> _commentsStore = new List<Comment>();

    public void OnGet()
    {
        Comments = _commentsStore;
    }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Content))
        {
            _commentsStore.Add(new Comment
            {
                UserName = UserName,
                Content = Content,
                CommentDate = DateTime.Now
            });
        }
        Comments = _commentsStore;
        return Page();
    }
}
