using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Data;
using System.Linq;

public class AdminDashboardModel : PageModel
{
    private readonly AppDbContext _context;
    public int TotalUsers { get; set; }
    public int TotalPosts { get; set; }
    public int TotalCategories { get; set; }
    public int TotalReviews { get; set; }

    public AdminDashboardModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        TotalUsers = _context.Users.Count();
        TotalPosts = _context.Posts.Count();
        TotalCategories = _context.Categories.Count();
        TotalReviews = _context.Comments.Count();
    }
}
