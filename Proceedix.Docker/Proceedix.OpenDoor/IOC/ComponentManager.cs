using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Proceedix.Interfaces;
using Proceedix.MessageBus.RabbitMQ;
using Proceedix.OpenDoorService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proceedix.OpenDoor.IOC
{
    class ComponentManager
    {

        #region - Private properties -

        private static WindsorContainer Container { get; } = new WindsorContainer();

        #endregion - Private properties -

        internal static WindsorContainer Initialize()
        {
            Container.Register(Component.For<IMessageBusService>().ImplementedBy<RabbitMQMessageBusService>());
            Container.Register(Component.For<IOpenDoorService>().ImplementedBy<OpenDoorPleaseService>());

            return Container;
        }


        /// <summary>
        ///     Returns a component instance of the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the component to return.
        /// </typeparam>
        /// <returns>
        ///     
        /// </returns>
        public static T GetInstance<T>() => Container.Resolve<T>();
    }
}
