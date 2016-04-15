namespace org.ian.location.client
{
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using baidumap;
    using http;

    public sealed class BaiduMapApi : ILocation
    {
        readonly static BaiduMapConfig Configuration;

        static BaiduMapApi()
        {
            Configuration = BaiduMapConfig.Load();
        }

        string ILocation.Location(double lon, double lat)
        {
            HttpHelper http = new HttpHelper(Configuration.Url,
                $@"ak={Configuration.Ak}",
                $@"location={lat},{lon}",
                $@"pois={Configuration.Pois}",
                $@"coordtype={Configuration.CoordType}",
                $@"output=json");

            string data = http.Get();
            return getResult(data);
        }

        async Task<string> ILocation.LocationAsync(double lon, double lat)
        {
            HttpHelper http = new HttpHelper(Configuration.Url,
                $@"ak={Configuration.Ak}",
                $@"location={lat},{lon}",
                $@"pois={Configuration.Pois}",
                $@"coordtype={Configuration.CoordType}",
                $@"output=json");
            string data = await http.GetAsync();
            return getResult(data);
        }

        static string getResult(string data)
        {
            JToken json = JToken.Parse(data);
            return json.SelectToken("result").ToString();
        }
    }
}
