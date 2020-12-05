using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var users = new List<AppUser>();
            var questionnaires = new List<Questionnaire>();
            var questions = new List<Question>();
            var answers1 = new List<Answer>();
            var answers2 = new List<Answer>();
            var answers3 = new List<Answer>();
            var userAnswers = new List<UserAnswer>();

            //var adminuser = userManager.Users.FirstOrDefault(u => u.Id == "db45c35f-a326-469f-b6ea-414d6e8e8c6d");

            //Her laver vi Admin role
            var result = await roleManager.RoleExistsAsync("Admin");
            if (!result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);
            }
            AppUser admin1 = null;

            if (!userManager.Users.Any())
            {
                admin1 = new AppUser
                {
                    UserName = "wulffadmin",
                    FirstName = "Nicolai",
                    LastName = "Wulff"
                };
                await userManager.CreateAsync(admin1, "wulffPa$$w0rd");
                await userManager.AddToRoleAsync(admin1, "Admin");

                users.Add(
                    new AppUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "karl@gmail.com",
                        FirstName = "Karlsmart",
                        LastName = "Ost",
                        UserName = "Karlo",
                    });
                users.Add(
                    new AppUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "karl2@gmail.com",
                        FirstName = "Karlen",
                        LastName = "Ostensen",
                        UserName = "Karlo2",
                    });
                foreach (var user in users)
                {
                    user.NormalizedEmail = user.Email.ToUpper();
                    user.NormalizedUserName = user.UserName.ToUpper();
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            answers1.Add(
                new Answer
                {
                    Description = "Yes",
                });
            answers1.Add(
                 new Answer
                 {
                     Description = "No",
                 });

            answers2.Add(
                new Answer
                {
                    Description = "Yes",
                });
            answers2.Add(
                 new Answer
                 {
                     Description = "No",
                 });
            answers3.Add(
              new Answer
              {
                  Description = "Water",
              });
            answers3.Add(
                 new Answer
                 {
                     Description = "Air",
                 });
            answers3.Add(
                new Answer
                {
                    Description = "Earth",
                });

            questions.Add(
                 new Question
                 {
                     Title = "Cat question",
                     Description = "Do you like cats",
                     Category = "Pets",
                     Answers = answers1
                 });
            questions.Add(
               new Question
               {
                   Title = "Fish question",
                   Description = "Do you like fish",
                   Category = "Food",
                   Answers = answers2
               });
            questions.Add(
             new Question
             {
                 Title = "General question",
                 Description = "In which element does your favorite pet resides?",
                 Category = "Food",
                 Answers = answers3
             });

            if (!context.Questionnaires.Any())
            {
                questionnaires.Add(
                 new Questionnaire
                 {
                     Id = "0001",
                     Title = "First questionnaire",
                     Description = "An enquiry into users favorite pets",
                     Target = 17,
                     Creator = admin1,
                     Questions = questions,
                     Started = DateTime.Now,
                 });
                context.Questionnaires.AddRange(questionnaires);
                context.SaveChanges();
            }

            if (!context.UserAnswers.Any())
            {

                userAnswers.Add(
                    new UserAnswer
                    {
                        AppUser = users[0],
                        UserId = users[0].Id,
                        Answer = answers1[0],
                        AnswerId = answers1[0].Id,
                        AnswerDate = DateTime.Now
                    });

                userAnswers.Add(
                    new UserAnswer
                    {
                        AppUser = users[0],
                        UserId = users[0].Id,
                        Answer = answers2[1],
                        AnswerId = answers2[1].Id,
                        AnswerDate = DateTime.Now
                    });
                userAnswers.Add(
                    new UserAnswer
                    {
                        AppUser = users[0],
                        UserId = users[0].Id,
                        Answer = answers3[1],
                        AnswerId = answers3[1].Id,
                        AnswerDate = DateTime.Now
                    });
                userAnswers.Add(
                    new UserAnswer
                    {
                        AppUser = users[1],
                        UserId = users[1].Id,
                        Answer = answers1[1],
                        AnswerId = answers1[1].Id,
                        AnswerDate = DateTime.Now
                    });
                userAnswers.Add(
                new UserAnswer
                {
                    AppUser = users[1],
                    UserId = users[1].Id,
                    Answer = answers2[1],
                    AnswerId = answers2[1].Id,
                    AnswerDate = DateTime.Now
                });
                userAnswers.Add(
                new UserAnswer
                {
                    AppUser = users[1],
                    UserId = users[1].Id,
                    Answer = answers3[1],
                    AnswerId = answers3[1].Id,
                    AnswerDate = DateTime.Now
                });
                  
                context.UserAnswers.AddRange(userAnswers);
                context.SaveChanges();
            }
        }
    }
}