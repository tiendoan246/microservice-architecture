using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Service.DataTransferObjects.Commands.Products;
using Products.Service.Products.Commands;
using Products.Service.Products.Handlers;
using Service.Common.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.Service.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductCommandHandlers handler;

        public ProductsController(IProductCommandHandlers handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public IActionResult Post(CreateProductCommand cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd.Name))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("code must be supplied in the body"),
                    ReasonPhrase = "Missing product code"
                };
                return Json(response);
            }

            try
            {
                var command = new CreateProduct(Guid.NewGuid(), cmd.Name, cmd.Description, cmd.Price);
                handler.Handle(command);

                return Json(string.Format("http://localhost:8181/api/products/{0}", command.Id));
            }
            catch (AggregateNotFoundException)
            {
                return NotFound();
            }
            catch (AggregateDeletedException)
            {
                return Conflict();
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
