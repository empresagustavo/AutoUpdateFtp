using System.Xml.Serialization;

namespace AutoUpdate.Services.Models.Xml
{
    [XmlRoot("AutoUpdate")]
    public class AutoUpdateXml
    {
        [XmlElement("Projects")]
        public ProjectsXml Projects { get; set; }
    }
}
