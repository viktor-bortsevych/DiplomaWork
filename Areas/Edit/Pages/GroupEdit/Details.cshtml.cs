using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.GroupEdit
{
    public class DetailsModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public DetailsModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Group Group { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var group = await _context.Groups.FirstOrDefaultAsync(m => m.ID == id);
            if (group == null)
            {
                return NotFound();
            }
            else 
            {
                Group = group;
            }
            return Page();
        }
    }
}
