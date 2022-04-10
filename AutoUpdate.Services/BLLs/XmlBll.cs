using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AutoUpdate.Services.Models.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.Services.BLLs
{
    public class XmlBll
    {
        public T DeserializeXmlToObject<T>(string pXmlFilePath) where T : class
        {
            try
            {
                if (File.Exists(pXmlFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    using (StreamReader reader = new StreamReader(pXmlFilePath))
                    {
                        return (T)serializer.Deserialize(reader);
                    }
                }

                throw new Exception($"Read Xml Configuration: The file was not found({pXmlFilePath}).");
            }
            catch (Exception error)
            {
                throw new Exception($"Deserialize Xml To Object: {error.Message}.");
            }
        }

        public void SerializeObjectToXml<T>(T pObject, string pXmlFilePath)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(pObject.GetType());

                using (StreamWriter writer = new StreamWriter(pXmlFilePath))
                {
                    xmlSerializer.Serialize(writer, pObject);
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Serialize Object To Xml: {error.Message}.");
            }
        }
    }
}
