using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class OneAdSetPayment(int paymentId, int reach, decimal price) : IOneTimePayment
    {
        public int paymentId { get; set; } = paymentId;
        public int reach { get; set; } = reach;
        public decimal price { get; set; } = price;
    }
}
