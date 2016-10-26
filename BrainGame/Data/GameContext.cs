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
        public Difficult(int beginRange, int endRange, int count = 49)
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
        public BaseGame(bool isOpen, short raiting, Difficult dif)
        {
            this.IsOpen = isOpen;
            this.Raiting = raiting;
            this.Diff = dif;
        }
    }
    public class GameAddition : BaseGame
    {
        public GameAddition(Boolean isOpen, Int16 raiting, Difficult dif) : base(isOpen, raiting, dif)
        {
        }
    }
    public class GameSubtraction : BaseGame
    {
        public GameSubtraction(Boolean isOpen, Int16 raiting, Difficult dif) : base(isOpen, raiting, dif)
        {
        }
    }
    public class GameMultiplication : BaseGame
    {
        public GameMultiplication(Boolean isOpen, Int16 raiting, Difficult dif) : base(isOpen, raiting, dif)
        {
        }
    }
    public class GameDivision : BaseGame
    {
        public GameDivision(Boolean isOpen, Int16 raiting, Difficult dif) : base(isOpen, raiting, dif)
        {
        }
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
