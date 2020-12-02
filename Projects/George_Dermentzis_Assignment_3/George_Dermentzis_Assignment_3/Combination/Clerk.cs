using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_3.Combination
{
    public class Clerk
    {
        private IPaymentMethod _paymentMethod;
        private IProduct _TShirt;

        public Clerk(IProduct TShirt, IPaymentMethod paymentMethod)
        {
            _TShirt = TShirt;
            _paymentMethod = paymentMethod;
        }

        public void Print()
        {
            Console.WriteLine("Please choose a T-Shirt");
            //Console.ReadKey();
            int cost = _TShirt.CalculatePriceTag();
            Console.WriteLine($"The cost of this T-Shirt is: {cost}\nHow will you pay for it?");
            //Console.ReadKey();
            _paymentMethod.Pay();
        }
    }
}
