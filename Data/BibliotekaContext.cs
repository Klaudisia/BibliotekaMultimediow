using Microsoft.EntityFrameworkCore;
using BibliotekaProjekt.Models; 

namespace BibliotekaProjekt.Data
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext(DbContextOptions<BibliotekaContext> options) : base(options)
        {
        }
        public DbSet<Zasob> Zasoby { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Film> Filmy { get; set; }
    }
}