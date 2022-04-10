using AutoUpdate.Services.BLLs;
using AutoUpdate.Services.Interfaces;
using AutoUpdate.Services.Models;

namespace AutoUpdate.Services.Services
{
    public class AutoUpdateService : IAutoUpdate
    {
        private readonly AutoUpdateBll _autoUpdateBll;

        public AutoUpdateService()
        {
            if (_autoUpdateBll == null)
            {
                _autoUpdateBll = new AutoUpdateBll();
            }
        }

        public void Update(FtpCredentials pFtpCredentials)
        {
            _autoUpdateBll.Update(pFtpCredentials);
        }

        public void Dispose() { }
    }
}
