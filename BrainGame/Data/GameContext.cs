using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public enum GameMode
    {
        GameAddition,
        GameSubtraction,
        GameMultiplication,
        GameDivision
    }

    public class BaseGame
    {
        public bool IsOpen { get; set; }
        public short Raiting { get; set; }        
        public int BeginRange { get; set; }
        public int EndRange { get; set; }
    }
    public class GameAddition : BaseGame
    {
        public int GameAdditionId { get; set; }
    }
    public class GameSubtraction : BaseGame
    {
        public int GameSubtractionId { get; set; }
    }
    public class GameMultiplication : BaseGame
    {
        public int GameMultiplicationId { get; set; }
    }
    public class GameDivision : BaseGame
    {
        public int GameDivisionId { get; set; }
    }

    public class GameContext : DbContext
    {
        public DbSet<GameAddition> GamesAddition { get; set; }
        public DbSet<GameSubtraction> GamesSubtraction { get; set; }
        public DbSet<GameMultiplication> GamesMultiplication { get; set; }
        public DbSet<GameDivision> GamesDivision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=GameContext.db");
        }
    }
}
