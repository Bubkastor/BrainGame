using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public struct Difficult
    {
        public int Count { get; set; }
        public int BeginRange { get; set; }
        public int EndRange { get; set; }
        public Difficult(int count, int beginRange, int endRange)
        {
            this.Count = count;
            this.BeginRange = beginRange;
            this.EndRange = endRange;
        }

    }
    public class BaseGame
    {
        public bool IsOpen { get; set; }
        public short Raiting { get; set; }
        public Difficult Diff { get; set; }

    }
    public class GameAddition : BaseGame
    {
    }
    public class GameSubtraction : BaseGame
    {
    }
    public class GameMultiplication : BaseGame
    {        
    }
    public class GameDivision : BaseGame
    {
    }    

    public class GameContext : DbContext
    {
        public DbSet<GameAddition> GamesAddition;
        public DbSet<GameSubtraction> GamesSubtraction;
        public DbSet<GameMultiplication> GamesMultiplication;
        public DbSet<GameDivision> GamesDivision;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=GameContext.db");
        }
    }
}
