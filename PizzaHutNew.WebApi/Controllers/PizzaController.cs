using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaHutNew.Domain;
using PizzaHutNew.Domain.Concrete;
using PizzaHutNew.Domain.Entities;
using System.Diagnostics;

namespace PizzaHutNew.WebApi.Controllers
{
    public class PizzaController : ApiController
    {
        //do dependency injection later
        PizzaHutRepository repo;
        public PizzaController()
        {
            repo = new PizzaHutRepository();
        }
        Lazy<List<javaOrder>> orderList = new Lazy<List<javaOrder>>();
        //get url api/api/pizza
        public IEnumerable<javaPizza> Get()
        {
            Debug.WriteLine("***************Request************************");
            return repo.Pizzas.AsEnumerable();
        }


        //post url api/api/pizza
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]javaOrder _order)
        {
            //orderList.Value.Add(_order);
            //order in output line
            Debug.WriteLine("OOOOOORRRRDDDDEEEeeeeeeeeeeeeeeeeeeeeeeeeeeeeERRRR");
            Debug.WriteLine(_order.ToString());
            repo.TakeOrder(_order);
            var response = Request.CreateResponse<javaOrder>(System.Net.HttpStatusCode.Created, _order);
            return response;
        }
       
    }
}
