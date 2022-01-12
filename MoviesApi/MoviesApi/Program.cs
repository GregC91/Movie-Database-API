﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MoviesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args)
                .Populate();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
