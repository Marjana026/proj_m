using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class FeatureModel : PageModel
{
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public List<Feature> Features { get; private set; }

    public void OnGet()
    {
        Features = new List<Feature>
        {
            new Feature { Name = "Category Filtering", Description = "Filter categories by location." },
            new Feature { Name = "Review System", Description = "View and analyze user reviews." },
            new Feature { Name = "Image Upload", Description = "Upload images for categories." },
            new Feature { Name = "Edit/Delete Posts", Description = "Edit and delete posts easily." },
            new Feature { Name = "Responsive Design", Description = "Works well on desktop and mobile." }
        };
    }
}
