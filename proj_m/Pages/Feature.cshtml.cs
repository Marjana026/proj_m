using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SyncSyntax.Models;
using System;

public class FeatureModel : PageModel
{
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public List<Feature> Features { get; private set; }
    public List<Post> TemplatePosts { get; private set; }

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

        TemplatePosts = new List<Post>();
        for (int i = 1; i <= 10; i++)
        {
            TemplatePosts.Add(new Post
            {
                Id = i,
                Title = $"Template Post {i}",
                Content = $"This is the content for template post {i}.",
                Author = $"Author {i}",
                CategoryId = 1,
                PublishedDate = DateTime.Now.AddDays(-i),
                IsFeatured = i % 2 == 0,
                ViewCount = i * 10,
                Tags = new List<string> { "tag1", "tag2" },
                Summary = $"Summary for post {i}",
                FeatureImagePath = null
            });
        }
    }
}
