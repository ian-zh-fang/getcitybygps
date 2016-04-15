namespace org.ian.location.client.baidumap
{
    using configuration;

    sealed class BaiduMapConfig
    {
        readonly static string ConfigSection = @"locationService";

        public string Ak { get; private set; }

        public string Url { get; private set; }

        public string CoordType { get; private set; }

        public string Pois { get; private set; }

        BaiduMapConfig()
        { }

        public static BaiduMapConfig Load()
        {
            SectionReader reader = new SectionReader(ConfigSection);
            string
                ak = reader.GetInnerText(@"baidumap/ak"),
                url = reader.GetInnerText(@"baidumap/apiUri"),
                coordtype = reader.GetInnerText(@"baidumap/coordtype"),
                pois = reader.GetInnerText(@"baidumap/pois");

            return new BaiduMapConfig
            {
                Ak = ak,
                CoordType = coordtype,
                Pois = pois,
                Url = url
            };
        }

        public string RequestUri(double lat, double lon)
        {
            return $"{Url}?ak={Ak}&location={lat},{lon}&pois={Pois}&coordtype={CoordType}&output=json";
        }
    }
}
