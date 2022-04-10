using Ionic.Zip;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.Services.BLLs
{
    public class ZipBll
    {
        public void UnzipFile(string pSourceZipFile, string pDestinyPathUnzipFiles)
        {
            try
            {
                if (!Directory.Exists(pDestinyPathUnzipFiles))
                {
                    Directory.CreateDirectory(pDestinyPathUnzipFiles);
                }

                using (ZipFile zipFile = new ZipFile(pSourceZipFile))
                {
                    zipFile.ExtractAll(pDestinyPathUnzipFiles, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Unzip File: {error.Message}.");
            }
        }
    }
}
