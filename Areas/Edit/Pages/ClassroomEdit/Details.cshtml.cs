using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.ClassroomEdit
{
    public class DetailsModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public DetailsModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Classroom Classroom { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Classrooms == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.ID == id);
            if (classroom == null)
            {
                return NotFound();
            }
            else 
            {
                Classroom = classroom;
            }
            return Page();
        }
    }
}
