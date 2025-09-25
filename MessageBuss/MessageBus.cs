
namespace MessageBuss
{
    public class MessageBus : IMessageBus
    {
        public MessageBus() { 
        

        }

        public Task PublicMessage(BaseMessage message, string queueName)
        {
            return Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
