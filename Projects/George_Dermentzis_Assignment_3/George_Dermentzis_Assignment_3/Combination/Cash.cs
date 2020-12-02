using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_3.Combination
{
    class Cash : IPaymentMethod
    {
        public void Pay()
        {
            Console.WriteLine("Sure you can pay with Cash");
        }
    }
}
