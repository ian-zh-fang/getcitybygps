namespace org.ian.location
{
    using System.Threading.Tasks;

    public interface ILocation
    {
        /// <summary>
        /// 根据 GPS 经纬度获取位置信息
        /// </summary>
        /// <param name="lon">GPS 经度</param>
        /// <param name="lat">GPS 维度</param>
        /// <returns></returns>
        string Location(double lon, double lat);

        /// <summary>
        /// 根据 GPS 经纬度获取位置信息
        /// </summary>
        /// <param name="lon">GPS 经度</param>
        /// <param name="lat">GPS 维度</param>
        /// <returns></returns>
        Task<string> LocationAsync(double lon, double lat);
    }
}
