using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.ClassroomEdit
{
    public class EditModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public EditModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Classroom Classroom { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Classrooms == null)
            {
                return NotFound();
            }

            var classroom =  await _context.Classrooms.FirstOrDefaultAsync(m => m.ID == id);
            if (classroom == null)
            {
                return NotFound();
            }
            Classroom = classroom;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(Classroom.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClassroomExists(string id)
        {
          return (_context.Classrooms?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
