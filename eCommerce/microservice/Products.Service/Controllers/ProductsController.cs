using System;
using System.Collections.Generic;
using Framework.DataModel.Response;
using Microsoft.AspNetCore.Mvc;
using Products.Common.Dto;
using Products.Service.DataTransferObjects.Commands.Products;
using Products.Service.Products.Commands;
using Products.Service.Products.Handlers;

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
        public IActionResult Post([FromBody]CreateProductCommand cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd.Name))
            {
                return Json(new CreateProductResponse
                {
                    Code = ErrorCode.Error
                });
            }

            var command = new CreateProduct(Guid.NewGuid(), cmd.Name, cmd.Description, cmd.Price);
            handler.Handle(command);

            return Json(new CreateProductResponse
            {
                Code = ErrorCode.Succeeded,
                CommandId = command.Id
            });
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
    }
}
