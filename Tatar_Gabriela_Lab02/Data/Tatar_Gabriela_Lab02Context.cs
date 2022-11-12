using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tatar_Gabriela_Lab02.Models;

namespace Tatar_Gabriela_Lab02.Data
{
    public class Tatar_Gabriela_Lab02Context : DbContext
    {
        public Tatar_Gabriela_Lab02Context (DbContextOptions<Tatar_Gabriela_Lab02Context> options)
            : base(options)
        {
        }

        public DbSet<Tatar_Gabriela_Lab02.Models.Book> Book { get; set; } = default!;

        public DbSet<Tatar_Gabriela_Lab02.Models.Publisher> Publisher { get; set; }

        public DbSet<Tatar_Gabriela_Lab02.Models.Author> Author { get; set; }

        public DbSet<Tatar_Gabriela_Lab02.Models.Category> Category { get; set; }

        public DbSet<Tatar_Gabriela_Lab02.Models.Member> Member { get; set; }

        public DbSet<Tatar_Gabriela_Lab02.Models.Borrowing> Borrowing { get; set; }

    }
}
