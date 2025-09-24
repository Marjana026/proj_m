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
