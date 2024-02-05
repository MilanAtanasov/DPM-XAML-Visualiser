using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM_XAML_Visualiser
{
    internal class Directory : Item
    {
        public List<Item> Children { get; set; }

        public Directory(string name) : base(name)
        {
            Children = new List<Item>();
        }

        // Method to add a child item to the directory
        public void AddChild(Item item)
        {
            Children.Add(item);
        }
    }
}
