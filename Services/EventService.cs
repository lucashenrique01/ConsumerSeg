using ConsumerSeg.Models;
using ConsumerSeg.Converters;

namespace ConsumerSeg.Services
{
    public class EventService
    {
        private static readonly HttpClient client = new HttpClient();
        public void sendProposal(Event eventt){
            DataEvent dataEvent = new DataEvent();
            dataEvent = DataEventConverter.jsonToDataEvent(eventt.data.ToString());
            Boolean responseProposal = true; //aqui seria para retornar de uma chamada a algum end point se para aquele id de client seria "valido" enviar uma proposta de seguro.            
            if(responseProposal){
                requestData(dataEvent.idCliente,dataEvent.idContrato,dataEvent);
            }else {
                Console.Write("Cliente não elegivel a receber uma proposta de seguro");
            }
        }

        public async Task requestData(string idCliente, string idContrato, DataEvent eventt){            
                var stringTask = client.GetStringAsync("http://localhost:8080/teste");
                var msg = await stringTask;
                Console.Write(msg);
                Console.Write(idCliente + idContrato);
                Console.Write("PASSOU");
                
        } 
    }
}