using Service.Common.MessageBus;

namespace Products.Service
{
    public static class ServiceLocator
    {
        public static IMessageBus Bus { get; set; }
    }
}
