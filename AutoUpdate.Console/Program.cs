using AutoUpdate.Services.Interfaces;
using AutoUpdate.Services.Models;
using AutoUpdate.Services.Services;
using System;
using System.Reactive.Linq;

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
                User = "Admin",
                Password = "adm123",
                Host = "ftp://127.0.0.1:21",
            };

            var observable = Observable.Interval(TimeSpan.FromSeconds(15));
            observable.Subscribe(x =>
            {
                _autoUpdate.Update(credentials);
            });

            System.Console.ReadKey();
        }
    }
}
