using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Pages
{
    public class LessonsModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public LessonsModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lesson> Lesson { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Lessons != null)
            {
                Lesson = await _context.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher).ToListAsync();
            }
        }
    }
}
