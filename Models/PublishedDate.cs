using Newtonsoft.Json;
namespace cat.itb.M6UF3EA1.Models;
public class PublishedDate
    {
        [JsonProperty("$date")] 
        public String date { get; set; }
    
        public override string ToString()
        {
            return 
                "PublishedDate{" + 
                "$date = '" + date + '\'' + 
                "}";
        }
    }
