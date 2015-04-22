using System;
using System.Collections.Generic;
using System.Linq;
using PizzaHutNew.Domain.Entities;

namespace PizzaHutNew.Domain.Concrete
{
    //class which provides access to PizzaHutDb
    public class PizzaHutRepository
    {
        private PizzaHutDbEntities context = new PizzaHutDbEntities();
        private List<javaPizza> javaPizzaLst = new List<javaPizza>(); 
        //get all pizzas
        public IQueryable<javaPizza> Pizzas
        {
            get {
                if (javaPizzaLst.Count == 0)
                {
                    foreach (var p in context.pizzas)
                    {
                        javaPizza j = new javaPizza();
                        j.id = p.id;
                        j.name = p.name;
                        j.ingridients = p.ingridients;
                        j.price = p.price;
                        javaPizzaLst.Add(j);
                    }   
                }
                
                return javaPizzaLst.AsQueryable();
            }
        }

        //public IQueryable<customer> Customers
        //{
        //    get { return context.customers; }
        //}

        //public IQueryable<order> Orders
        //{
        //    get { return context.orders; }
        //}
        ////add new to pizzas
        //public void CreatePizza(pizza _pizza)
        //{
        //    context.pizzas.Add(_pizza);
        //    context.SaveChanges();
        //}
        ////find pizza in pizzas
        //public pizza getPizzaById(int pid)
        //{
        //    return context.pizzas.Where(p => p.id == pid).SingleOrDefault();
        //}
        ////edit cur pizza
        //public void EditPizza(pizza _pizza)
        //{
        //    pizza pOld = context.pizzas.Where(x => x.id == _pizza.id).SingleOrDefault();
        //    if (pOld != null)
        //    {
        //        context.Entry(pOld).CurrentValues.SetValues(_pizza);
        //        context.SaveChanges();
        //    }
        //}

        private void CreateCustomer(string name, string phone)
        {
            customer cust = new customer();
            cust.name = name;
            if (phone.Length < 10)
            {
                int i = 10 - phone.Length;
                for (int t = 0;  t < i;  t++)
                {
                    phone = "0" + phone;
                }
            }
            cust.phone = phone;
            cust.id = 1;
            context.customers.Add(cust);
            context.SaveChanges();
        }

        private void CreateOrder(javaOrder _order)
        {
            order ord = new order();
            ord.customerId = context.customers.Max(p => p.id);
            ord.deliveryAddress = _order.deliveryAddress;
            ord.fullprice = _order.items.Sum(p => p.price * p.quantity);
            ord.processing = false;
            ord.orderTime = DateTime.Now;
            context.orders.Add(ord);
            context.SaveChanges();
        }

        private void CreateOrderItem(int orderId, int pizId, int amount)
        {
            cartItem newItem = new cartItem();
            newItem.orderId = orderId;
            newItem.pizzaId = pizId;
            newItem.quantity = amount;
            context.cartItems.Add(newItem);
            context.SaveChanges();
        }

        //takes received(from the fronend) order, and put it in all entities of relational db PizzaHutDb
        public void TakeOrder(javaOrder _order)
        {
            CreateCustomer(_order.client.name, _order.client.phone);
            CreateOrder(_order);
            int orderId = context.orders.Max(p => p.id);
            foreach (var oitem in _order.items)
            {
                CreateOrderItem(orderId, context.pizzas.Where(p => p.name == oitem.name).SingleOrDefault().id, oitem.quantity);
            }
        }
    }
}
