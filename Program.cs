using ConsumerSeg.Controllers;
using ConsumerSeg.Contexts;

namespace ConsumerSeg.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            BrokerContext brokerContext = new BrokerContext();
            string topicName = brokerContext.getTopic();
            ConsumerController consumerController = new ConsumerController();
            consumerController.ConsumerTopic(topicName);
        }
    }
}