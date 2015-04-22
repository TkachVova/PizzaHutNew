namespace PizzaHutNew.Domain.Entities
{
    public class javaCartItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        //for outputting in Debug
        public override string ToString()
        {
            return "cart item id  " + id.ToString() + "  " + name + "  " + price.ToString() + "  " + quantity.ToString();
        }
    }
}
