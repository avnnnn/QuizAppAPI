using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuizApp.Models
{
    public partial class QuizDBContext : DbContext
    {
        public QuizDBContext()
        {
        }

        public QuizDBContext(DbContextOptions<QuizDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserQuestionAnswer> UserQuestionAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QuizDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.ToTable("Choice");

                entity.Property(e => e.ChoiceText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Choices)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Choice__Question__6B24EA82");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Question__Catego__68487DD7");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ScoreId, e.BestCategoryId })
                    .HasName("PK__Score__7DD229D17BB437FA");

                entity.ToTable("Score");

                entity.Property(e => e.BestScore).HasColumnName("BestScore");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserQuestionAnswer>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.QuestionId, e.ChoiceId })
                    .HasName("PK__UserQues__60223FA0F499B5D9");

                entity.ToTable("UserQuestionAnswer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
