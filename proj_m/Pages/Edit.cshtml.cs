using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Data;
using SyncSyntax.Models;
using System.Linq;
using System.Threading.Tasks;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Post Post { get; set; }
    public SelectList Categories { get; set; }
    public string ErrorMessage { get; set; }

    public IActionResult OnGet(int id)
    {
        Post = _context.Posts.FirstOrDefault(p => p.Id == id);
        if (Post == null)
        {
            ErrorMessage = "Post not found.";
            return Page();
        }
        Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return Page();
        }
        var postInDb = _context.Posts.FirstOrDefault(p => p.Id == Post.Id);
        if (postInDb == null)
        {
            ErrorMessage = "Post not found.";
            return Page();
        }
        postInDb.Title = Post.Title;
        postInDb.Content = Post.Content;
        postInDb.Author = Post.Author;
        postInDb.CategoryId = Post.CategoryId;
        postInDb.PublishedDate = Post.PublishedDate;
        await _context.SaveChangesAsync();
        return RedirectToPage("/Category");
    }
}
