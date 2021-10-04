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
        public string Type { get; set; }

        [JsonProperty("features")]
        public List<FeatureItem> Features { get; set; }
    }



    

    public partial class FeatureItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        public GeometryItem Geometry { get; set; }

        [JsonProperty("properties")]
        public PropertiesCol Properties { get; set; }
    }

    public partial class GeometryItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class PropertiesCol
    {
        [JsonProperty("LandId")]
        public long LandId { get; set; }

        [JsonProperty("SumSpace")]
        public long SumSpace { get; set; }

        [JsonProperty("CLevelId")]
        public long CLevelId { get; set; }
    }
}
