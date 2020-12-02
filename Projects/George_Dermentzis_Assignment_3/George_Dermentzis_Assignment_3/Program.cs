using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using George_Dermentzis_Assignment_3.Combination;

namespace George_Dermentzis_Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextList = new List<Clerk>()
            {
                new Clerk(new TShirt(Color.GREEN, Size.L, Fabric.CASHMERE),new Money()),
                new Clerk(new TShirt(Color.BLUE, Size.M, Fabric.COTTON),new Cash()),
                new Clerk(new TShirt(Color.RED, Size.S, Fabric.LINEN),new Money()),
                new Clerk(new TShirt(Color.ORANGE, Size.M, Fabric.SILK),new Money()),
                new Clerk(new TShirt(Color.GREEN, Size.XS, Fabric.WOOL),new Cash()),
                new Clerk(new TShirt(Color.RED, Size.M, Fabric.RAYON),new Credit()),
                new Clerk(new TShirt(Color.BLUE, Size.XS, Fabric.POLYESTER),new Credit())
            };

            foreach (var context in contextList)
            {
                context.Print();
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
