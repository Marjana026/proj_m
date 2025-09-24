using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SyncSyntax.Data;
using SyncSyntax.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class CategoryModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _environment;
    public List<Category> Categories { get; set; }
    [BindProperty]
    public IFormFile ImageFile { get; set; }
    public string UploadMessage { get; set; }
    public string UploadedImagePath { get; set; }

    public CategoryModel(AppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public void OnGet()
    {
        Categories = _context.Categories.ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Categories = _context.Categories.ToList();
        if (ImageFile != null && ImageFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);
            var fileName = Path.GetFileName(ImageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(stream);
            }
            UploadedImagePath = $"/images/{fileName}";
            UploadMessage = "Image uploaded successfully!";
        }
        else
        {
            UploadMessage = "Please select an image file to upload.";
        }
        return Page();
    }
}
