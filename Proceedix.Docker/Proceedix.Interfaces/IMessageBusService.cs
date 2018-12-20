using System;
using System.Collections.Generic;
using System.Text;

namespace Proceedix.Interfaces
{
    public interface IMessageBusService
    {
        IObservable<IMessage> Messages { get; }
    }
}
