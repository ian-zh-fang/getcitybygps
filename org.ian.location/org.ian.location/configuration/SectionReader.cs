namespace org.ian.location.configuration
{
    using System;
    using System.Configuration;
    using System.Xml;

    public sealed class SectionReader
    {
        private readonly String _name;
        private XmlNode _section;

        public SectionReader(String sectionName)
        {
            _name = sectionName;
        }

        private XmlNode GetNode(String xpath)
        {
            if (_section == null)
            {
                _section = GetSection(_name) as XmlNode;
            }

            if (string.IsNullOrWhiteSpace(xpath))
                return _section;

            return _section.SelectSingleNode(xpath);
        }

        public XmlAttribute GetAttribute(String xpath, String attributeName)
        {
            return GetNode(xpath).Attributes[attributeName];
        }

        public String GetInnerText(String xpath)
        {
            return GetNode(xpath).InnerText;
        }

        private static object GetSection(String sectionName)
        {
            return ConfigurationManager.GetSection(sectionName);
        }
    }
}
