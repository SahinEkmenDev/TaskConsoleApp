using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp2
{


    public class content
    {
        public string Site { get; set; }
        public int len { get; set; }
    }
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine("Main Thread:"+Thread.CurrentThread.ManagedThreadId);
            List<string> Urllist = new List<string>()
            {
                "https://www.google.com",
                "https://www.youtube.com",
                "https://www.haberturk.com",
                "https://www.microsoft.com"

            };



            List<Task<content>> tasklist= new List<Task<content>>();
            Urllist.ToList().ForEach(x =>
            {
               tasklist.Add(GetContentAsync(x));


            });
           var firstdata= await Task.WhenAny(tasklist);
            Console.WriteLine($"ilk veri :{firstdata.Result.Site}--- Uzunluk:{firstdata.Result.len}");


        }

        public static async Task<content> GetContentAsync(string url)
        {
            content c = new content();
            var data = await new HttpClient().GetStringAsync(url);

            c.Site = url;
            c.len = data.Length;
            Console.WriteLine("GetContentAsync Thread :" + Thread.CurrentThread.ManagedThreadId);
            return c;
        }

    }



}
