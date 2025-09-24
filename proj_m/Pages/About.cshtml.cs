using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

public class AboutModel : PageModel
{
    public string CurrentTime { get; private set; }
    public string CompanyName { get; private set; }
    public string Mission { get; private set; }
    public List<string> TeamMembers { get; private set; }
    public string History { get; private set; }

    public void OnGet()
    {
        CurrentTime = DateTime.Now.ToString("F");
        CompanyName = "Contoso Contacts";
        Mission = "To simplify contact management for everyone.";
        TeamMembers = new List<string> { "Alice Smith", "Bob Johnson", "Charlie Lee" };
        History = "Founded in 2024, Contoso Contacts has helped thousands of users organize their contacts efficiently.";
    }
}
