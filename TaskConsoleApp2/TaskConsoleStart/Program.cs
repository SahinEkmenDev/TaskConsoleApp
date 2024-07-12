using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleStart
{
    public class content
    {
        public string Site { get; set; }
        public int len { get; set; }


    }

    public class status
    {
        public int threadId { get; set; }
        public DateTime date { get; set; }
    }
    internal class Program
    {
        static async void Main(string[] args)
        {
            var mytask = Task.Factory.StartNew((Obj) => 
            {
                Console.WriteLine("myTask  çalıştı");
                var  status=Obj as status;

                status.threadId= Thread.CurrentThread.ManagedThreadId;
            
            
            },new status() { date=DateTime.Now});
            await mytask;
            status s=mytask.AsyncState as status;
            Console.WriteLine(s.date);
            Console.WriteLine(s.threadId);
        }
    }
}
