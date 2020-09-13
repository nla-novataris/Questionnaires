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
       // public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Value>()
            .HasData(
                new Value { Id = 1, Name = "Value 101"},
                new Value { Id = 2, Name = "Value 102"},
                new Value { Id = 3, Name = "Value 103"}
            );

            builder.Entity<User>()
            .HasData(
                new User { Id = "1", UserName = "TestUser", FirstName = "Test", LastName = "User", IsAdmin= true, Added= DateTime.Now}
            );

            /*
            builder.Entity<UserAnswer>(x => x.HasKey(ua => 
                new { ua.UserId, ua.AnswerId }));
         
            builder.Entity<UserAnswer>()
                .HasOne(u => u.User)
                .WithMany(ua => ua.UserAnswers)
                .HasForeignKey(u => u.UserId);

            builder.Entity<UserAnswer>()
                  .HasOne(a => a.Answer)
                  .WithMany(ua => ua.UserAnswers)
                  .HasForeignKey(a => a.AnswerId);
          */
        }
    }
}
