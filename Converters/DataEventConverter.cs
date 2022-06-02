using ConsumerSeg.Models;
using Newtonsoft.Json;
namespace ConsumerSeg.Converters
{
    public class DataEventConverter
    {
         public static DataEvent jsonToDataEvent(string jsonString){
            DataEvent evento = new DataEvent();
            evento = JsonConvert.DeserializeObject<DataEvent>(jsonString);            
            return evento;
        }
    }
}