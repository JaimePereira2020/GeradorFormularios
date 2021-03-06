
using forms.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace forms.WebAPI.Data
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Form> Form { get; set; }
        public DbSet<Matrix> Matrix { get; set; }
        public DbSet<PossibilityAnswer> PossibilityAnswer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer {get; set;}
        public DbSet<User> User {get; set;}
        public DbSet<UserForm> UserForm {get; set;}
        public DbSet<Creator> Creator {get; set;}

    }


    
}