using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ViewModels;

namespace Models
{
    public class Level
    {
        public bool IsOpen { get; set; } = false;
        public short Raiting { get; set; }
        public int BeginRange { get; set; }
        public int EndRange { get; set; }
        public int Count { get; set; }
        public String RuleMode { get; set; }
        public Level() { }
        public Level(bool isOpen, short raiting, int beginRange, int endRange, int count = 49)
        {
            this.IsOpen = isOpen;
            this.Raiting = raiting;
            this.BeginRange = beginRange;
            this.EndRange = endRange;
            this.Count = count;
        }
    }
    public class FieldLevel
    {
        public List<Level> Levels { get; set; }
        public FieldLevel(GameMode mode)
        {
            List<BaseGame> levelsOptions = new List<BaseGame>();
            using (var db = new GameContext())
            {
                String ruleMode = "";
                switch (mode)
                {
                    case GameMode.GameAddition:
                        levelsOptions = db.GamesAddition.ToList<BaseGame>();
                        ruleMode = "RuleAddition";

                        break;
                    case GameMode.GameDivision:
                        levelsOptions = db.GamesDivision.ToList<BaseGame>();
                        break;
                    case GameMode.GameMultiplication:
                        levelsOptions = db.GamesMultiplication.ToList<BaseGame>();
                        ruleMode = "RuleMultiplication";

                        break;
                    case GameMode.GameSubtraction:
                        levelsOptions = db.GamesSubtraction.ToList<BaseGame>();
                        break;
                    default:
                        break;
                }
                Levels = new List<Level>();
                foreach (var item in levelsOptions)
                {
                    Level lvl = new Level(item.IsOpen, item.Raiting, item.BeginRange, item.EndRange);
                    lvl.RuleMode = ruleMode;
                    Levels.Add(lvl);
                }
                
            }

                
        }
        public void Add(Level level)
        {
            if (!Levels.Contains(level))
                Levels.Add(level);
        }
        public void Delete(Level level)
        {
            if (Levels.Contains(level))
                Levels.Remove(level);
        }

        internal void Update(Level sender)
        {
            //DatabaseUpdate
        }
    }
}
