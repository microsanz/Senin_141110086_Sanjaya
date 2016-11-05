using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Latihan_3_1
{
    class coloredComboObject
    {
        public string Name { get; set; }
        public Color Color { get; set; }

        public coloredComboObject(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
