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
    public class FtpBll
    {
        public FtpWebRequest GetConnection(FtpCredentials pFtpCredentials)
        {
            try
            {
                var ftpRequest = (FtpWebRequest)WebRequest.Create(pFtpCredentials.Host);
                ftpRequest.Credentials = new NetworkCredential(pFtpCredentials.User, pFtpCredentials.Password);

                return ftpRequest;
            }
            catch (Exception error)
            {
                throw new Exception($"Get FTP Connetion: {error.Message}.");
            }
        }

        public void Download(FtpWebRequest pFtpWebRequest, string pDestinyFileName)
        {
            try
            {
                pFtpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                pFtpWebRequest.UseBinary = true;

                using (FtpWebResponse ftpWebResponse = (FtpWebResponse)pFtpWebRequest.GetResponse())
                {
                    using (Stream stream = ftpWebResponse.GetResponseStream())
                    {
                        ServiceHelper.CreateLocalDirectory(pDestinyFileName);

                        using (FileStream fileStream = new FileStream(pDestinyFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            byte[] buffer = new byte[2048];
                            int bytesRead = stream.Read(buffer, 0 , buffer.Length);

                            while (bytesRead > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                bytesRead = stream.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }

                pFtpWebRequest.Abort();
            }
            catch (Exception error)
            {
                throw new Exception($"Download File From FTP: {error.Message}.");
            }
        }

    }
}
