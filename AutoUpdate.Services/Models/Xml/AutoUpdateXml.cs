using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
