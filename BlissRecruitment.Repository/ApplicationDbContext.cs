using BlissRecruitment.Domain.Questions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlissRecruitment.Repository
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChoiceEntity>().HasKey(x => x.Id);            
            
            modelBuilder.Entity<QuestionEntity>();
        }
    }
}
