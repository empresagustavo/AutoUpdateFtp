using AutoUpdate.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.Services.Interfaces
{
    public interface IAutoUpdate : IDisposable
    {
        void Update(FtpCredentials pFtpCredentials);





    }
}
