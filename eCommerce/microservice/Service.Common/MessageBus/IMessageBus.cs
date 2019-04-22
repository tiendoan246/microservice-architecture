using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Common.MessageBus
{
    public interface IMessageBus
    {
        void Publish<T>(T @event) where T : Event;
        void Send<T>(T command) where T : class, ICommand;
    }
}
