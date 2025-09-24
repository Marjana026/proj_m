using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class FeedbackModel : PageModel
{
    public class Feedback
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }

    [BindProperty]
    public string UserName { get; set; }
    [BindProperty]
    public string Comment { get; set; }
    [BindProperty]
    public int Rating { get; set; }

    public List<Feedback> Feedbacks { get; private set; } = new List<Feedback>();
    public double AverageRating => Feedbacks.Count == 0 ? 0 : Feedbacks.Average(f => f.Rating);

    public void OnGet()
    {
        LoadSampleFeedbacks();
    }

    public void OnPost()
    {
        LoadSampleFeedbacks();
        if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Comment) && Rating > 0)
        {
            Feedbacks.Insert(0, new Feedback { UserName = UserName, Comment = Comment, Rating = Rating });
        }
    }

    private void LoadSampleFeedbacks()
    {
        if (Feedbacks.Count == 0)
        {
            Feedbacks.AddRange(new[]
            {
                new Feedback { UserName = "Alice", Comment = "Great site!", Rating = 5 },
                new Feedback { UserName = "Bob", Comment = "Very useful.", Rating = 4 },
                new Feedback { UserName = "Charlie", Comment = "Needs more features.", Rating = 3 },
                new Feedback { UserName = "Dana", Comment = "Easy to use.", Rating = 5 },
                new Feedback { UserName = "Eve", Comment = "Good experience.", Rating = 4 }
            });
        }
    }
}
