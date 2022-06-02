using ConsumerSeg.Models;
using Newtonsoft.Json;
namespace ConsumerSeg.Converters
{
    public class EventResponseConverter
    {
        public static EventResponse jsonToEventResponse(string jsonString){
            EventResponse evento = new EventResponse();
            evento = JsonConvert.DeserializeObject<EventResponse>(jsonString);            
            return evento;
        }
    }
}