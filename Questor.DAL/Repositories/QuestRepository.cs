using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;

namespace Questor.DAL.Repositories
{
    public class QuestRepository : IQuestRepository
    {
        private readonly QuestorContext context;
        public QuestRepository(QuestorContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Quest quest)
        {
            await context.AddAsync(quest);
            await context.SaveChangesAsync();
            return quest.Id;
        }

        public async Task Delete(int questId)
        {
            context.Remove(await context.Quests.FirstOrDefaultAsync(x => x.Id == questId));
            await context.SaveChangesAsync();
        }

        public async Task Update(Quest quest)
        {
            context.Quests.Update(quest);
            await context.SaveChangesAsync();
        }

        public async Task<Quest> GetQuestById(int questId)
        {
            return await context.Quests.FirstOrDefaultAsync(x => x.Id == questId);
        }

        public async Task<List<Quest>> GetQuestsByUserId(string userId)
        {
            return await context.Quests.Where(x => x.User.Id == userId).ToListAsync();
        }

        public async Task<List<Quest>> GetAllPublicQuest()
        {
            return await context.Quests.Where(x => x.IsPublic == true).ToListAsync();
        }
    }
}
