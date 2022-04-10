using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoUpdate.Services.Models.Xml
{
	[XmlRoot(ElementName = "Version")]
	public class VersionXml
	{

		[XmlElement(ElementName = "Number")]
		public string Number { get; set; }

		[XmlElement(ElementName = "UpdateDate")]
		public DateTime UpdateDate { get; set; }

		[XmlElement(ElementName = "FilesCount")]
		public int FilesCount { get; set; }

		[XmlElement(ElementName = "FileSize")]
		public decimal FileSize { get; set; }
	}
}
