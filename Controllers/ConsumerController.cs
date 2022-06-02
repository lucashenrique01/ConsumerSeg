using Serilog;
using Confluent.Kafka;
using ConsumerSeg.Services;
using ConsumerSeg.Converters;
using ConsumerSeg.Contexts;

namespace ConsumerSeg.Controllers
{   
    class ConsumerController {        
        
        public void ConsumerTopic(string topicName){
           

            BrokerContext brokerContext = new BrokerContext();
            string bootstrapServers = brokerContext.getBroker();

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            logger.Information("Testando o consumo de mensagens com Kafka");  
            logger.Information($"BootstrapServers = {bootstrapServers}");
            logger.Information($"Topic = {topicName}");
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                using (var consumer = new ConsumerBuilder<Ignore, string>(brokerContext.ConfigConsumer()).Build())
                {
                    consumer.Subscribe(topicName);

                    try
                    {

                        while (true)
                        {
                            var cr = consumer.Consume(cts.Token);
                            logger.Information(
                                $"Mensagem lida: {cr.Message.Value}");
                            string eventoString = cr.Message.Value.ToString();                            
                            EventService eventService = new EventService();
                            eventService.sendProposal(EventConverter.jsonToEvent(eventoString));
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                        logger.Warning("Cancelada a execução do Consumer...");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exceção: {ex.GetType().FullName} | " +
                             $"Mensagem: {ex.Message}");
            }
            

        }
    }
}
