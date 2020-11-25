using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            var users = new List<User>();
            var questionnaires = new List<Questionnaire>();
            var questions = new List<Question>();
            var answers1 = new List<Answer>();
            var answers2 = new List<Answer>();
            var userAnswers = new List<UserAnswer>();

            /*
            users.Add(
                new User
                {
                    Id = "00001",
                    FirstName = "Karl",
                    LastName = "Ost",
                    UserName = "Karlo",
                    IsAdmin = true,
                });
            users.Add(
                   new User
                   {
                       Id = "00002",
                       FirstName = "Karl 2",
                       LastName = "Ost 2",
                       UserName = "Karlo 2",
                       IsAdmin = true,
                   });
            */

            if (!userManager.Users.Any())
            {
                users.Add(
                    new User
                    {
                        Id = "00001",
                        Email = "karl@gmail.com",
                        FirstName = "Karlsmart",
                        LastName = "Ost",
                        UserName = "Karlo",
                        IsAdmin = true,
                    });
                users.Add(
                    new User
                    {
                        Id = "00002",
                        FirstName = "Karl 2",
                        LastName = "Ost 2",
                        UserName = "Karlo 2",
                        IsAdmin = true,
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

            questions.Add(
                 new Question
                 {
                     Title = "Second question",
                     Description = "Do you like cats",
                     Category = "Pets",
                     Answers = answers1
                 });
            questions.Add(
               new Question
               {
                   Title = "First question",
                   Description = "Do you like fish",
                   Category = "Food",
                   Answers = answers2
               });
            questionnaires.Add(
             new Questionnaire
             {
                 Id = "0001",
                 Title = "First questionnaire",
                 Description = "An enquiry into the nature of questionnaires",
                 Target = 17,
                 Creator = users[0],
                 Questions = questions,
                 Started = DateTime.Now,
             });

            questionnaires.Add(
                 new Questionnaire
                 {
                     Id = "0002",
                     Title = "Second questionnaire",
                     Description = "A second enquiry into the nature of questionnaires",
                     Target = 37,
                     Creator = users[1],
                     Questions = questions,
                     Started = DateTime.Now,
                 });

            userAnswers.Add(
                new UserAnswer
                {
                    User = users[0],
                    UserId = users[0].Id,
                    Answer = answers1[0],
                    AnswerId = answers1[0].Id,
                    AnswerDate = DateTime.Now
                });

            userAnswers.Add(new UserAnswer
            {
                User = users[1],
                UserId = users[1].Id,
                Answer = answers1[1],
                AnswerId = answers1[1].Id,
                AnswerDate = DateTime.Now
            });

            if (!context.Users.Any())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Questionnaires.Any())
            {
                context.Questionnaires.AddRange(questionnaires);
                context.SaveChanges();
            }

            if (!context.UserAnswers.Any())
            {
                context.UserAnswers.AddRange(userAnswers);
                context.SaveChanges();
            }
        }
    }
}