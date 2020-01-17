using BlissRecruitment.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace BlissRecruitment.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<QuestionEntity> Question { get; set; }

        public DbSet<ChoiceEntity> Choice { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChoiceEntity>(x => 
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.Votes);
                x.Property(p => p.Choice);
            });
            
            modelBuilder.Entity<QuestionEntity>(x=> 
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Question);
                x.Property(p => p.ImageUrl);
                x.Property(p => p.ThumbUrl);
                x.Property(p => p.PublishedAt);
                x.HasMany(p => p.Choices).WithOne();
            });
        }
    }
}
