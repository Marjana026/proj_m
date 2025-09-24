using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

public class AboutModel : PageModel
{
    public string CurrentTime { get; private set; }

    public void OnGet()
    {
        CurrentTime = DateTime.Now.ToString("F");
    }
}
