using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            var users = new List<User>();
            var questionnaires = new List<Questionnaire>();
            var questions = new List<Question>();
            var answers1 = new List<Answer>();
            var answers2 = new List<Answer>();
            var questionAnswers = new List<QuestionAnswer>();

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

            if (!context.Users.Any())
            {

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            //if (!context.Answers.Any())
            //{
            //    context.Answers.AddRange(answers);
            //    context.SaveChanges();
            //}

            //if (!context.Questions.Any())
            //{
            //    context.Questions.AddRange(questions);
            //    context.SaveChanges();
            //}

            //if (!context.QuestionAnswers.Any())
            //{
            //    context.QuestionAnswers.AddRange(questionAnswers);
            //    context.SaveChanges();
            //}

            if (!context.Questionnaires.Any())
            {
                context.Questionnaires.AddRange(questionnaires);
                context.SaveChanges();
            }
        }
    }
}