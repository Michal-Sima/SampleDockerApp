using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SampleDockerApp.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var user = await _context.User.FindAsync(UserId);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
