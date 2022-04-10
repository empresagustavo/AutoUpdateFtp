using AutoUpdate.Services.Models;
using System;

namespace AutoUpdate.Services.Interfaces
{
    public interface IAutoUpdate : IDisposable
    {
        void Update(FtpCredentials pFtpCredentials);





    }
}
