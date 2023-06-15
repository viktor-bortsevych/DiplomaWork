using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.TeacherEdit
{
    public class IndexModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public IndexModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Teacher> Teacher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Teachers != null)
            {
                Teacher = await _context.Teachers.ToListAsync();
            }
        }
    }
}
