using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cosma_Simona_Lab2.Models;

namespace Cosma_Simona_Lab2.Data
{
    public class Cosma_Simona_Lab2Context : DbContext
    {
        public Cosma_Simona_Lab2Context (DbContextOptions<Cosma_Simona_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Cosma_Simona_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Cosma_Simona_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Cosma_Simona_Lab2.Models.Author> Author { get; set; } = default!;

    }
}
