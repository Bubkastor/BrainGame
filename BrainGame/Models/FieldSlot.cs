using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Models
{
    public class Slot
    {
        public int value { get; set; }
        public bool visible { get; set; } = true;
        public Slot()
        {
            var rand = new Random();
            value = rand.Next(1, 9);
        }
    }
    public class FieldSlot
    {
        public Slot [][] Numbers { get; set; }        
        public FieldSlot()
        {
            Numbers = new Slot[5][];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = new Slot[5];
            }
            for (int i = 0; i < Numbers.Length; i++)
            {
                for (int j = 0; j < Numbers[i].Length; j++)
                {
                    Numbers[i][j] = new Slot();
                }
                
            }

        }
    }
}
