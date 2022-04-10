using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoUpdate.Services.Models.Xml
{
	[XmlRoot(ElementName = "Versions")]
	public class VersionsXml
	{

		[XmlElement(ElementName = "Version")]
		public List<VersionXml> VersionList { get; set; }
	}
}
