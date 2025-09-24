using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class ReviewModel : PageModel
{
    public class Review
    {
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public List<Review> Reviews { get; private set; }
    public int TotalReviews => Reviews.Count;
    public double AverageRating => Reviews.Count == 0 ? 0 : Reviews.Average(r => r.Rating);
    public Dictionary<int, int> RatingCounts { get; private set; }

    public void OnGet()
    {
        Reviews = new List<Review>();
        for (int i = 1; i <= 50; i++)
        {
            Reviews.Add(new Review
            {
                ReviewerName = $"User {i}",
                Rating = (i % 5) + 1,
                Comment = $"This is a template review number {i}. The service was {(i % 2 == 0 ? "great" : "good")}."
            });
        }
        RatingCounts = Reviews.GroupBy(r => r.Rating)
            .ToDictionary(g => g.Key, g => g.Count());
        // Ensure all ratings 1-5 are present
        for (int i = 1; i <= 5; i++)
        {
            if (!RatingCounts.ContainsKey(i))
                RatingCounts[i] = 0;
        }
    }
}
