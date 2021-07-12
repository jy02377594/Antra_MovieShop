using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC
{
    public class Program
    {
        //private readonly IMovieService _movieService;
        //public Program(IMovieService movieService)
        //{
        //    _movieService = movieService;
        //}
        //public string GetMovieById(int Id)
        //{
        //    var movie = _movieService.GetMovieById(Id);
        //    if (movie == null) return null;
        //    var res = Newtonsoft.Json.JsonConvert.SerializeObject(movie);
        //    return res;
        //}
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
            //int[] a = { };
            //int[] b = { 1, 2, 3 };
            //a.FirstOrDefault();
            //b.SingleOrDefault();
            //Console.Read();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
