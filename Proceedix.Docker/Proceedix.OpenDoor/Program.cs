using Proceedix.Interfaces;
using Proceedix.OpenDoor.IOC;
using System;

namespace Proceedix.OpenDoor
{
    class Program
    {
        static void Main(string[] args)
        {
            // IOC 
            ComponentManager.Initialize();

            var logic = new Logic(ComponentManager.GetInstance<IMessageBusService>(), ComponentManager.GetInstance<IOpenDoorService>());
            logic.Start();


            Console.ReadKey();
        }
    }
}
