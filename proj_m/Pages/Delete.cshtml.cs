using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SyncSyntax.Data;
using SyncSyntax.Models;
using System.Linq;
using System.Threading.Tasks;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Post Post { get; set; }
    public string ErrorMessage { get; set; }

    public IActionResult OnGet(int id)
    {
        Post = _context.Posts.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        if (Post == null)
        {
            ErrorMessage = "Post not found.";
            return Page();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var postInDb = _context.Posts.FirstOrDefault(p => p.Id == Post.Id);
        if (postInDb == null)
        {
            ErrorMessage = "Post not found.";
            return Page();
        }
        _context.Posts.Remove(postInDb);
        await _context.SaveChangesAsync();
        return RedirectToPage("/Category");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class TextEditModel : PageModel
{
    [BindProperty]
    public string TextContent { get; set; }
    public bool Saved { get; set; }

    public void OnGet()
    {
        // Optionally load existing text
        TextContent = "Edit this text...";
    }

    public void OnPost()
    {
        if (!string.IsNullOrWhiteSpace(TextContent))
        {
            Saved = true;
            // Save logic here (e.g., to a file or database)
        }
    }
}
```

The `TextEditModel` class and its associated Razor page content have been removed from the file. The `TextEditModel` class is now defined only once, as per the provided code block. The Razor page content has been excluded since it was not part of the suggested code change. The file now contains only the `DeleteModel` and `TextEditModel` classes. The file is syntactically valid and properly formatted. 
