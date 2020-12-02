using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_3.Combination
{
    class Credit : IPaymentMethod
    {
        public void Pay()
        {
            Console.WriteLine("Perfect you can pay with Credit Card");
        }
    }
}
