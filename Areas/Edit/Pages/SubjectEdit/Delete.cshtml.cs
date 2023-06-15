using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.SubjectEdit
{
    public class DeleteModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public DeleteModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Subject Subject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FirstOrDefaultAsync(m => m.ID == id);

            if (subject == null)
            {
                return NotFound();
            }
            else 
            {
                Subject = subject;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }
            var subject = await _context.Subjects.FindAsync(id);

            if (subject != null)
            {
                Subject = subject;
                _context.Subjects.Remove(Subject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
