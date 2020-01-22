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
            modelBuilder.UseIdentityColumns();

            modelBuilder.HasSequence<int>("QuestionId")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>("ChoiceId")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<ChoiceEntity>(x => 
            {                
                x.Property(k => k.Id).ValueGeneratedOnAdd();
                x.Property(p => p.Votes);
                x.Property(p => p.Choice);
            });
            
            modelBuilder.Entity<QuestionEntity>(x=> 
            {                
                x.Property(k => k.Id).ValueGeneratedOnAdd();
                x.Property(p => p.Question);
                x.Property(p => p.ImageUrl);
                x.Property(p => p.ThumbUrl);
                x.Property(p => p.PublishedAt);
                x.HasMany(p => p.Choices).WithOne();
            });            
        }          
    }
}
