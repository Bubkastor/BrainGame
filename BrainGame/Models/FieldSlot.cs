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
        public Slot(int value, bool visible)
        {            
            Value = value;
            Visible = visible;
        }
    }
    public class FieldSlot
    {
        public List<Slot> Numbers { get; set; }      
        public String Name { get; set; }  
        public FieldSlot(String Name)
        {
            this.Name = Name;
            this.Numbers = new List<Slot>();
            var rand = new Random();
            bool visible = false;
            for (int i = 0; i < 25; i++)
            {               
                this.Numbers.Add(new Slot(rand.Next(1, 9), visible));
                visible = !visible;
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
