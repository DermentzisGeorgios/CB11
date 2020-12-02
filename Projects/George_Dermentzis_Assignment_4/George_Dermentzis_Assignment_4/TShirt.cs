using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using George_Dermentzis_Assignment_4.Enums;

namespace George_Dermentzis_Assignment_4
{
    class TShirt
    {
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Fabric Fabric { get; set; }

        public TShirt(Color color, Size size, Fabric fabric)
        {
            Color = color;
            Size = size;
            Fabric = fabric;
        }

        public void Print()
        {
            Console.WriteLine("{0, 12} | {1, 12} | {2, 12}", Color, Size, Fabric);
        }
    }
}
