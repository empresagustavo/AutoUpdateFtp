using AutoUpdate.Services.Help;
using AutoUpdate.Services.Interfaces;
using AutoUpdate.Services.Models;
using AutoUpdate.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.Console
{
    public class Program
    {
        private static IAutoUpdate _autoUpdate;    
        static void Main(string[] args)
        {
            _autoUpdate = new AutoUpdateService();

            var credentials = new FtpCredentials
            {
                User ="Admin",
                Password ="adm123",
                Host = "ftp://127.0.0.1:21",
            };

            var observable = Observable.Interval(TimeSpan.FromMinutes(5));
            observable.Subscribe(x =>
            {
                _autoUpdate.Update(credentials);
            });

            //while (true)
            //{

                System.Console.ReadKey();
            //}

        }
    }
}
