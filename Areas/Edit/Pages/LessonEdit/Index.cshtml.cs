using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.LessonEdit
{
    public class IndexModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public IndexModel(DiplomaWork.Data.ApplicationDbContext context)
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
