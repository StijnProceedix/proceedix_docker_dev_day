using Proceedix.Interfaces;
using Proceedix.MessageBus.Messages;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace Proceedix.OpenDoor
{
    class Logic
    {
        IMessageBusService MessageBusService { get; }
        IOpenDoorService OpenDoorService { get; }

        public Logic(IMessageBusService messageBusService, IOpenDoorService openDoorService)
        {
            this.MessageBusService = messageBusService;
            this.OpenDoorService = openDoorService;
        }


        public void Start()
        {
            MessageBusService.Messages.OfType<OpenDoorPleaseMessage>().Subscribe(OnMessageReceived);
        }
        

        private void OnMessageReceived(OpenDoorPleaseMessage message)
        {

        }

    }
}
