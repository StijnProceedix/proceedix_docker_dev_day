using Proceedix.Interfaces;
using Proceedix.MessageBus.Messages;
using System;
using System.Reactive.Subjects;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Proceedix.MessageBus.RabbitMQ
{
    public class RabbitMQMessageBusService: IMessageBusService, IDisposable
    {
        private readonly Subject<IMessage> messages;
        public IObservable<IMessage> Messages => messages;

        IConnection connection;
        IModel channel;



        public RabbitMQMessageBusService()
        {
            messages = new Subject<IMessage>();

            ConnectionFactory factory = new ConnectionFactory();

            var user = "admin";
            var pass = "demo";
            var hostName = "rabbitmq-daemon";
            var port = "5672";
            string queue = "open_door";

            factory.Uri = new Uri($"amqp://{user}:{pass}@{hostName}:{port}/vhost");

            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    messages.OnNext(OpenDoorPleaseMessage.Create());
                };
                channel.BasicConsume(queue: queue,
                                     autoAck: true,
                                     consumer: consumer);                
            }
        }

        public void Dispose()
        {
            channel.Close();
            connection.Close();
        }
    }
}
