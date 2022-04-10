using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoUpdate.Services.Models.Xml
{
    [XmlRoot("Project")]
    public class ProjectXml
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        
        [XmlElement("FtpFileVersion")]
        public string FtpFileVersion { get; set; }
        
        [XmlElement("FtpFileDownload")]
        public string FtpFileDownload { get; set; }
        
        [XmlElement("LocalFileVersion")]
        public string LocalFileVersion { get; set; }
    }
}
