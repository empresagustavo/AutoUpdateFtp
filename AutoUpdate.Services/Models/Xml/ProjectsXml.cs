using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoUpdate.Services.Models.Xml
{
    [XmlRoot("Projects")]
    public class ProjectsXml
    {
        [XmlElement("Project")]
        public List<ProjectXml> ProjectList { get; set; }
    }
}
