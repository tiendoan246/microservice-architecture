using Framework.DataModel.Response;
using System;

namespace Products.Common.Dto
{
    public class CreateProductResponse: ResponseBase
    {
        public Guid CommandId { get; set; }
    }
}
