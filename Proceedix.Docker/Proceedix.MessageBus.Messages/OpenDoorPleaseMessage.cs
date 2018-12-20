using Proceedix.Interfaces;
using System;

namespace Proceedix.MessageBus.Messages
{
    public class OpenDoorPleaseMessage: IMessage
    {

        public OpenDoorPleaseMessage()
        {

        }


        public static OpenDoorPleaseMessage Create()
        {
            return new OpenDoorPleaseMessage();
        }

    }
}
