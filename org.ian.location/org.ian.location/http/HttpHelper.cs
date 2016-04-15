namespace org.ian.location.http
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;

    public sealed class HttpHelper
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUri { get; private set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string RequestParameters { get; private set; }

        /// <summary>
        /// 编码方式
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public HttpHelper(string url, params string[] args)
        {
            RequestUri = url;
            string[] arr = args.Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
            RequestParameters = string.Join("&", arr);
        }

        public async Task<string> PostAsync()
        {
            string data = @"";
            using (WebClient client = new WebClient())
            {
                byte[] buffer = Encoding.GetBytes(RequestParameters);
                buffer = await client.UploadDataTaskAsync(RequestUri, buffer);
                data = Encoding.GetString(buffer);
            }
            return data;
        }

        public string Post()
        {
            string data = @"";
            using (WebClient client = new WebClient())
            {
                byte[] buffer = Encoding.GetBytes(RequestParameters);
                buffer = client.UploadData(RequestUri, buffer);
                data = Encoding.GetString(buffer);
            }
            return data;
        }

        public async Task<string> GetAsync()
        {
            string data = @"";
            using (WebClient client = new WebClient())
            {
                string url = $"{RequestUri}?{RequestParameters}";
                byte[] buffer = await client.DownloadDataTaskAsync(url);
                data = Encoding.GetString(buffer);
            }
            return data;
        }

        public string Get()
        {
            string data = @"";
            using (WebClient client = new WebClient())
            {
                string url = $"{RequestUri}?{RequestParameters}";
                byte[] buffer = client.DownloadData(url);
                data = Encoding.GetString(buffer);
            }
            return data;
        }
    }
}
