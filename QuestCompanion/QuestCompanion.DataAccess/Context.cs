using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestCompanion.Model;

namespace QuestCompanion.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class Context : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Questline> Questlines { get; set; }
        public DbSet<Log> Changelogs { get; set; }

    }
}
