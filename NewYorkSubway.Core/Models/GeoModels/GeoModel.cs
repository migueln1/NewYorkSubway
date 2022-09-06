namespace NewYorkSubway.Core.Models
{
    public class Feature
    {
        public string? type { get; set; }
        public Properties? properties { get; set; }
        public Geometry? geometry { get; set; }
    }

    public class Geometry
    {
        public string? type { get; set; }
        public List<double>? coordinates { get; set; }
    }

    public class Properties
    {
        public string? line { get; set; }
        public string? name { get; set; }
        public string? objectid { get; set; }
        public string? url { get; set; }
    }
    public class GeoModelRoot
    {
        public string? type { get; set; }
        public List<Feature>? features { get; set; }
    }
}
