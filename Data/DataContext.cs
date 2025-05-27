using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AIC.Models;

namespace AIC.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<AIC.Models.Author> Author { get; set; } = default!;
        public DbSet<AIC.Models.Book> Book { get; set; } = default!;
        public DbSet<AIC.Models.AuthorShip> AuthorShip { get; set; } = default!;
    }
}
