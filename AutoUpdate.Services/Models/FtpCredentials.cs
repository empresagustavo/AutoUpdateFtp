using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.Services.Models
{
    public class FtpCredentials
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }
}
