using Cosma_Simona_Lab2.Data;
using Cosma_Simona_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosma_Simona_Lab2.Pages.Publishers
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Cosma_Simona_Lab2.Data.Cosma_Simona_Lab2Context _context;

        public CreateModel(Cosma_Simona_Lab2.Data.Cosma_Simona_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
