using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBuss
{
    public interface IMessageBus
    {
        Task PublicMessage(BaseMessage message,string queueName);
    }
}
