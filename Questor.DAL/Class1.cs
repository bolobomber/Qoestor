using Microsoft.EntityFrameworkCore;

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


    }
}