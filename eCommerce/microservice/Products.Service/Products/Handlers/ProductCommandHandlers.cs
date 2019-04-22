using Products.Common.Dto;
using Products.Service.Products.Commands;
using Service.Common.Repository;
using System;

namespace Products.Service.Products.Handlers
{
    public class ProductCommandHandlers: IProductCommandHandlers
    {
        private readonly IRepository repository;

        public ProductCommandHandlers(IRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateProduct message)
        {
            // Validation 
            // ProductDto existingProduct = null;

            // Process
            var series = new Products.Domain.Product(message.Id, message.Name, message.Description, message.Price);
            repository.Save(series);
        }

        public void Handle(AlterProduct message)
        {
            var product = repository.GetById<Products.Domain.Product>(message.Id);

            int committedVersion = message.OriginalVersion;

            if (!String.Equals(product.Name, message.NewTitle, StringComparison.OrdinalIgnoreCase))
            {
                product.ChangeName(message.NewTitle, committedVersion++);
            }

            if (!String.Equals(product.Description, message.NewDescription, StringComparison.OrdinalIgnoreCase))
            {
                product.ChangeDescription(message.NewDescription, committedVersion++);
            }

            if (message.NewPrice != product.Price)
            {
                product.ChangePrice(message.NewPrice, committedVersion);
            }

            repository.Save(product);
        }
    }
}
