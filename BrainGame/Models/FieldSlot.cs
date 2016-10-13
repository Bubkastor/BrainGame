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
        public int Value { get; set; }
        public bool Visible { get; set; } = true;
        public bool IsSelected { get; set; } = false;
        public Slot() { }
        public Slot(int value, bool visible = true) 
        {            
            Value = value;
            Visible = visible;
        }
    }
    public class FieldSlot
    {
        public List<Slot> Numbers { get; set; }      
        public FieldSlot()
        {
            this.Numbers = new List<Slot>();
            var rand = new Random();            
            for (int i = 0; i < 49; i++)
            {               
                this.Numbers.Add(new Slot(rand.Next(1, 9)));
            }           
        }
        public void Add(Slot slot)
        {
            if (!Numbers.Contains(slot))            
                Numbers.Add(slot);            
        }
        public void Delete(Slot slot)
        {
            if (Numbers.Contains(slot))
                Numbers.Remove(slot);
        }
    }
}
