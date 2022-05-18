using Microsoft.EntityFrameworkCore;
using Questor.DAL.Models;

namespace Questor.DAL
{
    public class QuestorContext : DbContext
    {
        public QuestorContext()
        {

        }
        public QuestorContext(DbContextOptions<QuestorContext> options) : base(options)
        {

        }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Quest> Quests { get; set; }

        public DbSet<Question> Questions{get;set;}
        public DbSet<QuestResult> QuestResults {get;set;}
        public DbSet<TypeOfQuestion> TypeOfQuestions {get;set;}
        public DbSet<Answer> Answers {get;set;}

    }
}