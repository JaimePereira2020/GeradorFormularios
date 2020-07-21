using forms.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace forms.WebAPI.Data
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Formulario> Formulario { get; set; }
    }
}