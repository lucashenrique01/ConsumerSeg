using Newtonsoft.Json.Linq;
namespace ConsumerSeg.Models
{
    public class EventResponse
    {
        public JObject? cliente {get; set;}
        public JObject? contrato {get; set;}
    }
}