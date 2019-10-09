using Quizz.Models;
using Quizz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizz.DAL
{
    public class InitialInitializator : System.Data.Entity.DropCreateDatabaseIfModelChanges<QuizzDbContext>
    {
        protected override void Seed(QuizzDbContext context)
        {
            var users = new List<User>
            {
                new User{Firstname="Mariia", LastName="Levytska",Email="mariia.levytska99@gmail.com",Password="123456789"}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();


        }
    }
}