using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackerApi
{
    public class GeoJsonResultItem
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "FeatureCollection";

        [JsonProperty("features")]
        public List<FeatureItem> Features { get; set; }
    }



    

    public  class FeatureItem
    {
       

        [JsonProperty("type")]
        public string Type { get; set; } = "Feature";

        [JsonProperty("geometry")]
        public GeometryItem Geometry { get; set; } 

        [JsonProperty("properties")]
        public PropertiesCol Properties { get; set; }
    }

    public  class GeometryItem
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "Polygon";

        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }
    }

    public  class PropertiesCol
    {
        
    }
}
