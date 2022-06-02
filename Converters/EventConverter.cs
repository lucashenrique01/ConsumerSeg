using ConsumerSeg.Models;
using Newtonsoft.Json;
namespace ConsumerSeg.Converters
{
    public class EventConverter
    {
        public static Event jsonToEvent(string jsonString){
            Event evento = new Event();
            evento = JsonConvert.DeserializeObject<Event>(jsonString);            
            return evento;
        }
    }
}