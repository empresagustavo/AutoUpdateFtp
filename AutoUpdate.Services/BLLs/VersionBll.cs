using AutoUpdate.Services.Help;
using AutoUpdate.Services.Models;
using AutoUpdate.Services.Models.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace AutoUpdate.Services.BLLs
{
    public class VersionBll
    {
        private FtpBll _ftpBll;

        public VersionBll(FtpBll pFtpBll)
        {
            _ftpBll = pFtpBll;
        }

        public KeyValuePair<string, string> GetVersions(FtpCredentials pFtpCredentials, ProjectXml pProjectXml)
        {
            try
            {
                var credentiails = new FtpCredentials
                {
                    User = pFtpCredentials.User,
                    Password = pFtpCredentials.Password,
                    Host = pFtpCredentials.Host + pProjectXml.FtpFileVersion,
                };

                string ftpVersion = GetFtpVersion(credentiails, pProjectXml);
                string currentVersion = GetCurrentVersion(pProjectXml.LocalFileVersion);

                return new KeyValuePair<string, string>(ftpVersion, currentVersion);
            }
            catch (Exception error)
            {
                throw new Exception($"Validate Versions: {error.Message}.");
            }
        }

        private string GetFtpVersion(FtpCredentials pFtpCredentials, ProjectXml pProjectXml)
        {
            try
            {
                FtpWebRequest connetion = _ftpBll.GetConnection(pFtpCredentials);

                string file = $@"{ServiceHelper.CreateLocalPath("Temp")}\FtpVersion.txt";

                _ftpBll.Download(connetion, file);

                string versionText = GetFileVersionText(file);

                return versionText;
            }
            catch (Exception error)
            {
                throw new Exception($"Get FTP Version: {error.Message}.");
            }
        }

        private string GetCurrentVersion(string pLocalFile)
        {
            try
            {
                string file = $@"{Environment.CurrentDirectory}\{pLocalFile}";

                if (File.Exists(file))
                {
                    string version = FileVersionInfo.GetVersionInfo(file).FileVersion;

                    return version;
                }

                return "0.0.0.0";
            }
            catch (Exception error)
            {
                throw new Exception($"Get Current Version: {error.Message}.");
            }
        }

        private string GetFileVersionText(string pFileVersion)
        {
            try
            {
                string textFile = File.ReadAllText(pFileVersion);

                return textFile.Replace("Current:", "");
            }
            catch (Exception error)
            {
                throw new Exception($"Get Number Version: {error.Message}.");
            }
        }

        public int GetNumberVersion(string pVersion)
        {
            try
            {
                string version = pVersion.Replace("Current:", "").Replace(".", "").Replace(",", "");

                return Convert.ToInt32(version);
            }
            catch (Exception error)
            {
                throw new Exception($"Get Number Version: {error.Message}.");
            }
        }
    }
}
