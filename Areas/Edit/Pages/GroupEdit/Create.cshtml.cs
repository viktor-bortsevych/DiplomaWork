using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.GroupEdit
{
    public class CreateModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public CreateModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeacherID"] = new SelectList(_context.Teachers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Group Group { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Groups == null || Group == null)
            {
                return Page();
            }

            _context.Groups.Add(Group);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
