using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Quizz.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quizz.Repository
{
    public class QuizzDbContext : DbContext
    {
        public QuizzDbContext():base("DefaultConnection")
        {

        }
       public DbSet<User>Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
