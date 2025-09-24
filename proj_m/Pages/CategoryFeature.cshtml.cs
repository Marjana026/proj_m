using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Models;
using System.Collections.Generic;
using System.Linq;

public class CategoryFeatureModel : PageModel
{
    public class CategoryInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCount { get; set; }
    }

    public List<CategoryInfo> TopCategories { get; private set; }

    public void OnGet()
    {
        // Example: get top 3 categories by post count
        var categories = new List<Category>
        {
            new Category { Name = "Business", Description = "Business contacts", Posts = new List<Post> { new Post(), new Post() } },
            new Category { Name = "Family", Description = "Family contacts", Posts = new List<Post> { new Post() } },
            new Category { Name = "Friends", Description = "Friends contacts", Posts = new List<Post> { new Post(), new Post(), new Post() } },
            new Category { Name = "Other", Description = "Other contacts", Posts = new List<Post>() }
        };
        TopCategories = categories
            .Select(c => new CategoryInfo { Name = c.Name, Description = c.Description, PostCount = c.Posts?.Count ?? 0 })
            .OrderByDescending(c => c.PostCount)
            .Take(3)
            .ToList();
    }
}
