﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
namespace Models
{
    public class Level
    {
        public bool IsOpen { get; set; } = false;
        public short Raiting { get; set; }
        public Difficult Diff { get; set; }
        public Level() { }
        public Level(bool isOpen, short raiting, Difficult diff)
        {
            this.IsOpen = isOpen;
            this.Raiting = raiting;
            this.Diff = diff;
        }
    }
    public class FieldLevel
    {
        public List<Level> Levels { get; set; }
        public FieldLevel(List<BaseGame> lists)
        {
            foreach (var item in lists)
                Levels.Add(new Level(item.IsOpen, item.Raiting, item.Diff));
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
    }
}
