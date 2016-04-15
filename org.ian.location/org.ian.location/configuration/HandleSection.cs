namespace org.ian.location.configuration
{
    using System.Configuration;
    using System.Xml;

    public sealed class HandleSection : IConfigurationSectionHandler
    {
        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            return section;
        }
    }
}
