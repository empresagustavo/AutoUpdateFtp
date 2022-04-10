using System;
using System.IO;
using System.Linq;

namespace AutoUpdate.Services.Help
{
    public static class ServiceHelper
    {
        public static string GetFileType(this string pFile)
        {
            try
            {
                if (!pFile.Contains("."))
                {
                    throw new Exception($"Get File Type: This value not as valid file.");
                }

                string[] arrayString = pFile.Split('.');
                return arrayString.LastOrDefault();
            }
            catch (Exception error)
            {
                throw new Exception($"Get File Type: {error.Message}.");
            }
        }

        public static string CreateLocalPath(string pPath)
        {
            try
            {
                string path = $@"{Environment.CurrentDirectory}\{pPath}";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
            catch (Exception error)
            {
                throw new Exception($"Get File Temp Version: {error.Message}.");
            }
        }

        public static string CreateLocalFile(string pFile)
        {
            try
            {
                if (!File.Exists(pFile))
                {
                    File.Create(pFile);
                }

                return pFile;
            }
            catch (Exception error)
            {
                throw new Exception($"Create Local File: {error.Message}.");
            }
        }

        public static int GetFilesCount(string pPath)
        {
            try
            {
                if (Directory.Exists(pPath))
                {
                    return Directory.GetFiles(pPath).Length;
                }

                return 0;
            }
            catch (Exception error)
            {
                throw new Exception($"Create Local File: {error.Message}.");
            }
        }
        
        public static decimal GetFileSize(string pFile)
        {
            try
            {
                if (File.Exists(pFile))
                {
                    return new FileInfo(pFile).Length;
                }

                return 0;
            }
            catch (Exception error)
            {
                throw new Exception($"Create Local File: {error.Message}.");
            }
        }

        public static string CreateLocalDirectory(string pLocation)
        {
            try
            {
                string directory = "";
                string[] strinArray = pLocation.Split('\\');
                foreach (var path in strinArray)
                {
                    if (!path.Contains("."))
                    {
                        directory += $@"{path}\";
                    }
                }

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                return directory;
            }
            catch (Exception error)
            {
                throw new Exception($"Create Local File: {error.Message}.");
            }
        }



    }
}
