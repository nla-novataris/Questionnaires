using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Questionnaire>()
                .HasOne(q => q.Creator)
                .WithMany(q => q.Questionnaires)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Questionnaire>()
               .HasMany(q => q.Questions)
               .WithOne(q => q.Questionnaire)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Question>()
           .HasMany(q => q.Answers)
           .WithOne(q => q.Question)
           .OnDelete(DeleteBehavior.Cascade);

            //Many to many relations
            //Primary key
            builder.Entity<UserAnswer>(x => x.HasKey(qa =>
                new { qa.UserId, qa.AnswerId }));

            builder.Entity<UserAnswer>()
                .HasOne(q => q.AppUser)
                .WithMany(qa => qa.UserAnswers)
                .HasForeignKey(q => q.UserId);

            builder.Entity<UserAnswer>()
                  .HasOne(a => a.Answer)
                  .WithMany(qa => qa.UserAnswers)
                  .HasForeignKey(a => a.AnswerId);
        }
    }
}
