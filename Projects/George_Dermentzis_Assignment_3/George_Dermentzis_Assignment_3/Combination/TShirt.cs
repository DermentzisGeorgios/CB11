using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_3.Combination
{
    public class TShirt : IProduct
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

        public int CalculatePriceTag()
        {
            int price = 0;
            switch (Fabric)
            {
                case Fabric.WOOL: 
                    price = 10;
                    break;
                case Fabric.COTTON:
                    price = 20;
                    break;
                case Fabric.POLYESTER:
                    price = 30;
                    break;
                case Fabric.RAYON:
                    price = 40;
                    break;
                case Fabric.LINEN:
                    price = 50;
                    break;
                case Fabric.CASHMERE:
                    price = 60;
                    break;
                case Fabric.SILK:
                    price = 70;
                    break;
            }

            return price;
        }
    }
}
