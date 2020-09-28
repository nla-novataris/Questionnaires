using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public DbSet<QuestionAnswer> QuestionAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {   
            // To add data to the db follow the pattern bellow, or configure Seed.cs
            //builder.Entity<User>()
            //.HasData(
            //    new User
            //    {
            //        Id = "1",
            //        UserName = "TestUser",
            //        FirstName = "Test",
            //        LastName = "User",
            //        IsAdmin = true,
            //        Added = DateTime.Now
            //    }
            //);

            //Many to many relations
            //Primary key
            //builder.Entity<QuestionAnswer>(x => x.HasKey(qa =>
            //    new { qa.QuestionID, qa.AnswerID }));

            //builder.Entity<QuestionAnswer>()
            //    .HasOne(q => q.Question)
            //    .WithMany(qa => qa.QuestionAnswers)
            //    .HasForeignKey(q => q.QuestionID);

            //builder.Entity<QuestionAnswer>()
            //      .HasOne(a => a.Answer)
            //      .WithMany(qa => qa.QuestionAnswers)
            //      .HasForeignKey(a => a.AnswerID);
        }
    }
}
