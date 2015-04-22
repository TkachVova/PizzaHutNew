using System.Collections.Generic;

namespace PizzaHutNew.Domain.Entities
{
    //class for receiving order information from frontend in api controller
    public class javaOrder
    {
        //for storing information about clients
        public javaCustomer client { get; set; }
        //delivery address is not in customer because it can be always different
        public string deliveryAddress { get; set; }
        public IEnumerable<javaCartItem> items { get; set; }
        public override string ToString()
        {
            string ret = client.ToString();
            foreach (var item in items)
            {
                ret += "  " + item.ToString();
            }
            return ret;
        }
    }
}
