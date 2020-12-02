using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_3.Combination
{
    class Money : IPaymentMethod
    {
        public void Pay()
        {
            Console.WriteLine("Excellent you will pay with Bank Transfer");
        }
    }
}
