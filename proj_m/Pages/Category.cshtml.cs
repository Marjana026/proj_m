using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Data;
using SyncSyntax.Models;
using System.Collections.Generic;
using System.Linq;

public class CategoryModel : PageModel
{
    private readonly AppDbContext _context;
    public List<Category> Categories { get; set; }

    public CategoryModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Categories = _context.Categories.ToList();
    }
}
