using Cosma_Simona_Lab2.Data;
using Cosma_Simona_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosma_Simona_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Cosma_Simona_Lab2.Data.Cosma_Simona_Lab2Context _context;

        public DeleteModel(Cosma_Simona_Lab2.Data.Cosma_Simona_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(i =>i.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Includerea categoriilor asociate pentru a le elimina înainte de ștergere
            var book = await _context.Book
                .Include(b => b.Author)
                .Include(i => i.BookCategories)
                .FirstOrDefaultAsync(i => i.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            //var book = await _context.Book.FindAsync(id);
            // Ștergerea relațiilor cu categoriile
            if (book.BookCategories != null && book.BookCategories.Any())
            {
                _context.BookCategory.RemoveRange(book.BookCategories);
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
