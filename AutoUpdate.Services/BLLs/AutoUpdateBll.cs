using AutoUpdate.Services.Help;
using AutoUpdate.Services.Models;
using AutoUpdate.Services.Models.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.Services.BLLs
{
    public class AutoUpdateBll
    {
        private readonly FtpBll _ftpBll;
        private readonly ZipBll _zipBll;
        private readonly XmlBll _xmlBll;
        private readonly VersionBll _versionBll;

        private AutoUpdateXml _autoUpdateXml;
        private VersionsXml _versionsXml;

        public AutoUpdateBll()
        {
            if (_ftpBll == null)
            {
                _ftpBll = new FtpBll();
                _zipBll = new ZipBll();
                _xmlBll = new XmlBll();
                _versionBll = new VersionBll(_ftpBll);
            }
        }

        public void Update(FtpCredentials pFtpCredentials)
        {
            try
            {
                string fileConfig = $@"{Environment.CurrentDirectory}\Configurations.xml";

                _autoUpdateXml = _xmlBll.DeserializeXmlToObject<AutoUpdateXml>(fileConfig);

                foreach (var project in _autoUpdateXml.Projects.ProjectList)
                {
                    var versions = _versionBll.GetVersions(pFtpCredentials, project);

                    int ftpVersion = _versionBll.GetNumberVersion(versions.Key);
                    int CurrentVersion = _versionBll.GetNumberVersion(versions.Value);

                    if (ftpVersion > CurrentVersion)
                    {
                        var credentiails = new FtpCredentials
                        {
                            User = pFtpCredentials.User,
                            Password = pFtpCredentials.Password,
                            Host = pFtpCredentials.Host + project.FtpFileDownload,
                        };

                        FtpWebRequest connection = _ftpBll.GetConnection(credentiails);

                        string fileType = project.FtpFileDownload.GetFileType();
                        string destinyFileName = $@"{Environment.CurrentDirectory}\{project.Name}\Versions\{versions.Key}.{fileType}";

                        _ftpBll.Download(connection, destinyFileName);

                        if (fileType == "zip")
                        {
                            string directoryProject = $@"{Environment.CurrentDirectory}\{project.Name}";
                            string localFileVersion = $@"{directoryProject}\Versions\Version.txt";

                            _zipBll.UnzipFile(destinyFileName, directoryProject);

                            ServiceHelper.CreateLocalDirectory(localFileVersion);
                            int filesCount = ServiceHelper.GetFilesCount(directoryProject);
                            decimal fileSize = ServiceHelper.GetFileSize(destinyFileName);

                            if (!File.Exists(localFileVersion))
                            {
                                _versionsXml = new VersionsXml();

                                _xmlBll.SerializeObjectToXml<VersionsXml>(_versionsXml, localFileVersion);
                            }

                            _versionsXml = _xmlBll.DeserializeXmlToObject<VersionsXml>(localFileVersion);

                            _versionsXml.VersionList.Add(new VersionXml
                            {
                                FilesCount = filesCount,
                                Number = versions.Key,
                                UpdateDate = DateTime.Now,
                                FileSize = fileSize
                            });

                            _xmlBll.SerializeObjectToXml<VersionsXml>(_versionsXml, localFileVersion);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Update \n{error.Message}.");
            }
        }
    }
}
