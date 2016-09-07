using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BaseGame
    {
        public int Score { get; set; }
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
