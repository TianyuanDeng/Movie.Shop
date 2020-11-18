using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Movie.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    //Kestral server 
    //Main method is the entry point wich will create a hosting environment so that ASP.NET core can work inside that one
    //its gonna call a class called Startup -->
    //if something is wrong or not working first place to look for is startup class.

    //Middleware is new ASP.NET Core
    //When you make a request in ASP.NET Core MVC/API... the request will go through some middleware
    //Requst -> M1 -> some processing --> M2 -- > M3 --> Destination 
    
    //ASP.NET Core has some built-in middlewares where every request will go throuogh those middlewares
    //We as a a dveloper can create our own custom Middlewares also and plugin to pipeline

    //http://example.com/Sudetnts/Index ==> Get
    //SudentController class and Index action 
    
    //Traditional based routing / Convention based Routing
    //Attribute based routing --> most used one 
    //what is routing? --> Pattern matching technique 

    //http://example.com/Students/List/2019/December

}
