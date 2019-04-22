using Products.Service.Products.Commands;

namespace Products.Service.Products.Handlers
{
    public interface IProductCommandHandlers
    {
        void Handle(CreateProduct message);
        void Handle(AlterProduct message);
    }
}
