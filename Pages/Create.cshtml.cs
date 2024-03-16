using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace SampleDockerApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext dbContext; 
        public CreateModel(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string? Name { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            User user = new User();
            user.Email = Email;
            user.Username = Name;
            dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public string? Email { get; set; }
    }

}
